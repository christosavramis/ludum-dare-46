using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 0;

    public void Awake()
    {
        damage = GetComponent<Enemy>().damage;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        StarTurret starTurret = collision.transform.GetComponent<StarTurret>();
        if(starTurret != null)
        {
            starTurret.UseEnergyEnemy(damage);
            GetComponent<Enemy>().DieAttack();
            this.enabled = false;
        }
    }
}
