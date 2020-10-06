using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    //score manager
    public static int score;
    public TextMeshProUGUI scoreHolder;
    public TextMeshProUGUI scoreHolderShop;
    Camera cameraMain;
    //CameraShake cameraShake;
    private void Awake()
    {
        instance = this;
        cameraMain = Camera.main;
        //score = 9000;
        scoreHolder.text = score.ToString();
        scoreHolderShop.text = score.ToString();
    }

    public static bool CanBuy(int ammount)
    {
        return score >= ammount;
    }
    public static void Buy(int ammount)
    {
        score -= ammount;
        instance.scoreHolder.text = score.ToString();
        instance.scoreHolderShop.text = score.ToString();
    }




    public static void KillEnemy(Enemy enemy)
    {
        GameObject _deathParticles = Instantiate(enemy.deathParticles, enemy.transform.position, Quaternion.identity) ;
        Debug.Log("enemy score "+ enemy.score);
        score += enemy.score;
        instance.scoreHolder.text = score.ToString();
        instance.scoreHolderShop.text = score.ToString();
        //instance.cameraShake.Shake(enemy.shakeAmount, enemy.shakeLength);
        AudioManager.instance.PlaySound("EnemyDeath");
        Destroy(enemy.gameObject);
        Destroy(_deathParticles, 2f);
    }

}