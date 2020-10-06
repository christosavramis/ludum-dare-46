using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float healthMax = 100f;
    public float movementSpeed = 1f;
    public bool canMove = true;
    [HideInInspector]
    public float healthCur;
    public float damage = 10f;
    public int score = 25;

    [Header("Required")]
    public GameObject deathParticles;
    public Transform target;
    public GameObject healthBarSlider;
    private Slider healthBar;

    private bool turned;

    private void Awake()
    {
        healthBar = healthBarSlider.GetComponent<Slider>();
        healthCur = healthMax;
        healthBar.maxValue = healthMax;
        healthBar.value = healthCur;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

  
    public void Update()
    {
        if (canMove)
        {
            Vector3 dir = target.position - transform.position;
            dir = dir.normalized;
            if (dir.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            transform.Translate(new Vector3(dir.x, dir.y, 0) * Time.deltaTime * movementSpeed, Space.World);
        }
        
    }



    public void ReceiveDamage(float ammount)
    {
        if (healthCur - ammount <= 0)
        {
            GameManager.KillEnemy(this);
        }
        else
        {
            healthCur -= ammount;   
            healthBar.value = healthCur;
        }
    }

    public void DieAttack()
    {
        score = 0;
        GameManager.KillEnemy(this);
    }
    public void Die()
    {
        GameManager.KillEnemy(this);
    }
}
