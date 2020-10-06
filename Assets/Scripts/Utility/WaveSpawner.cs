using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    public static WaveSpawner instance;
    [Header("WaveUI")]
    public TextMeshProUGUI nextWaveUI;

    [Header("SpawnPoints")]
    [SerializeField]
    Transform[] spawnpoints;

    [Header("wave settings")]
    [SerializeField]
    Wave[] waves;
    public float timeBetweenWaves = 5f;
    [HideInInspector]
    public int waveNumber= 0;

    private int nextWave = 0;
    private float waveCountdown;
    private float searchCountDown = 1f;
    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }
    private void Awake()
    {
        WaveSpawner.instance = this;
        nextWaveUI.text = waveNumber.ToString();
    }

    void Update()
    {
        //Debug.Log(state);
        if (state == SpawnState.WAITING)
        {   
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
        }
        else if (waveCountdown <= 0 && state == SpawnState.COUNTING)
        {
            StartCoroutine(SpawnWave());
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }


    IEnumerator SpawnWave()
    {
        state = SpawnState.SPAWNING;
        Debug.Log(" wave number" + nextWave);

        foreach (GameObject enemy in waves[nextWave].enemies)
        {
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(1f / waves[nextWave].rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(GameObject _enemy)
    {
        //Spawn Enemy
        Transform sp = spawnpoints[Random.Range(0, spawnpoints.Length)];
        Instantiate(_enemy, sp.transform.position, Quaternion.identity);
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            return GameObject.FindGameObjectsWithTag("Enemy").Length > 0;
        }
        return true;
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            //waveCountdown = 0;
            SceneLoader.Ending();
            this.enabled = false;

        }
        else
        {
            nextWave++;
            waveCountdown++;
        }
        waveNumber++;
        nextWaveUI.text = waveNumber.ToString();

    }
}


