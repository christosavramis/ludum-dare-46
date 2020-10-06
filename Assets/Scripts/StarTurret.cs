using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarTurret : MonoBehaviour
{
    [Header("Stats")]
    public float energyMax = 100f;
    public float energyCur = 100f;
    public float regenerationRate = 10f;
    public float regenerationAmmount = 1f;
    private float lastRegen = 0f;

    private bool domeblock = false;
    public float domeRate = 1f;

    [Header("Required")]
    public GameObject sliderHolder;
    private Slider energyBar;
    public GameObject domeUI;

    public void Awake()
    {
        domeUI.SetActive(false);
        energyCur = energyMax;
        energyBar = sliderHolder.GetComponent<Slider>();
        energyBar.value = energyCur;
        energyBar.maxValue = energyMax;
    }

    public void Update()
    {
        if(Time.time >= lastRegen)
        {
            energyCur = Mathf.Clamp(energyCur + regenerationAmmount,0, energyMax);
            energyBar.value = energyCur;
            lastRegen = Time.time + 1 / regenerationRate;
        }

    }

    public void UseEnergy(float ammount)
    {
        energyCur = Mathf.Clamp(energyCur - ammount, 0, energyMax);
        energyBar.value = energyCur;
    }
    public void UseEnergyEnemy(float ammount)
    {
        if (domeblock){
            domeblock = false;
            domeUI.SetActive(false);
            StartCoroutine(RegenDrone());
            return;
        }
        energyCur = Mathf.Clamp(energyCur - ammount, 0, energyMax);
        energyBar.value = energyCur;
        if (energyCur <= 0)
        {
            SceneLoader.EndingLose();
        }
    }

    public bool HasEnergy(float ammount)
    {
        return energyCur >= ammount;
    }

    public void IncreaseEnergyPool(float _ammount)
    {
        energyMax = _ammount;
        regenerationRate++;
    }

    public void IncEnergyRegen(float _ammount)
    {
        regenerationAmmount = _ammount;
        regenerationRate++;
    }

    public void DomeUpgrade()
    {
        domeblock = true;
        domeUI.SetActive(true);
        Debug.Log("dome activated");
    }

    IEnumerator RegenDrone()
    {
        yield return new WaitForSeconds(domeRate);
        domeblock = true;
        domeUI.SetActive(true);
        Debug.Log("dome activated");
        yield break;
    }
}
