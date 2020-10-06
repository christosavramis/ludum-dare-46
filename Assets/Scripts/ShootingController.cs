using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShootingController : MonoBehaviour
{
    [Header("Required")]
    public Transform firePoint;
    public Transform starCannon;
    public Transform starCannonReloadUI;

    [Header("Stats")]
    public float energyPerShoot = 10f;
    public float fireRate = 10f;
    private float timeToFire = 0;
    public float damage=10f;

    [Header("Effects")]
    public GameObject bulletTrailPref;
    public GameObject bulletShootParticles;
    private float timeToSpawnEffect = 0f;
    public float effectSpawnRate = 5;
    private StarTurret starTurret;
    private void Awake()
    {
        starTurret = starCannon.parent.GetComponent<StarTurret>();


        if (firePoint == null)
        {
            Debug.LogWarning("Missing firepoint reference from StarTurret");
        }
        if (starCannon == null)
        {
            Debug.LogWarning("StarCannon reference missing from aim controller");
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time > timeToFire && starTurret.HasEnergy(energyPerShoot))
        {
            starCannonReloadUI.gameObject.SetActive(true);
        }
        
        if (Input.GetButtonDown("Jump") && Time.time > timeToFire && starTurret.HasEnergy(energyPerShoot))
        {
            starCannonReloadUI.gameObject.SetActive(false);
            Shoot();
            starCannon.parent.GetComponent<StarTurret>().UseEnergy(energyPerShoot);
            timeToFire = Time.time + 1 / fireRate;
        }
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            //Damage Enemy
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {   
             
                enemy.ReceiveDamage(damage);
            }
        }

        if (Time.time >= timeToSpawnEffect)
        {
            if (hitInfo)
            {
                Effect(hitInfo.point);
                timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
            }
            else
            {
                Effect(firePoint.position + firePoint.right * 100);
                timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
            }
        }

    }
    public void IncreaseDamage(float _damage)
    {
        damage = _damage;
    }
    
    public void IncreaseEnergyPerShot(float _ammount)
    {
        energyPerShoot = _ammount;
    }

    public void IncreaseFirerate(float _ammount)
    {
        fireRate = _ammount;
    }

    void Effect(Vector3 hitPosition)
    {
        GameObject bulletShootParticle = Instantiate(bulletShootParticles, firePoint.transform.position, Quaternion.identity);
        Destroy(bulletShootParticle, 0.2f);
        GameObject bulletTrail = Instantiate(bulletTrailPref, firePoint.transform.position, Quaternion.identity);
        LineRenderer lineRenderer = bulletTrail.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, hitPosition);
        Destroy(bulletTrail, 0.1f);
        AudioManager.instance.PlaySound("Shot");
    }
}

