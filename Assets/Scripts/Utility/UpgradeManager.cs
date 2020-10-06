using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [System.Serializable]
    class UpgradeComponent
    {
        public string name;
        public Sprite sprite;
        public int cost;
        public UnityEvent functionality;

        //call the other functions
        public void CallOtherFunctions()
        {
            functionality.Invoke();
        }
    }

    //the starting update
    int dmg_i = 0;
    int fire_i = 0;
    int enPool_i = 0;
    int enRate_i = 0;
    int turn_i = 0;

    [Header("Upgrade list")]
    [SerializeField]
    UpgradeComponent[] upgradeComponentDamage;
    [Space]
    [SerializeField]
    UpgradeComponent[] upgradeComponentEnPool;
    [Space]
    [SerializeField]
    UpgradeComponent[] upgradeComponentEnRate;
    [Space]
    [SerializeField]
    UpgradeComponent[] upgradeComponentFire;
    [Space]
    [SerializeField]
    UpgradeComponent[] upgradeComponentTurn;

    [Header("Shopitem display")]
    public Shopitem[] displayItem;
  

    private void Awake()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        //display 0
        if (dmg_i < upgradeComponentDamage.Length)
        {
            UpgradeComponent comp = null;
            comp = upgradeComponentDamage[dmg_i];
            displayItem[0].ChangeItem(comp.name, comp.cost, comp.sprite);
        }
        else
        {
            displayItem[0].gameObject.SetActive(false);
        }

        //display 1
        if (fire_i < upgradeComponentFire.Length)
        {
            UpgradeComponent comp = null;
            comp = upgradeComponentFire[fire_i];
            displayItem[1].ChangeItem(comp.name, comp.cost, comp.sprite);
        }
        else
        {
            displayItem[1].gameObject.SetActive(false);
        }

        //display 2
        if (enPool_i < upgradeComponentEnPool.Length)
        {
            UpgradeComponent comp = null;
            comp = upgradeComponentEnPool[enPool_i];
            displayItem[2].ChangeItem(comp.name, comp.cost, comp.sprite);
        }
        else
        {
            displayItem[2].gameObject.SetActive(false);
        }

        //display 3
        if (enRate_i < upgradeComponentEnRate.Length)
        {
            UpgradeComponent comp = null;
            comp = upgradeComponentEnRate[enRate_i];
            displayItem[3].ChangeItem(comp.name, comp.cost, comp.sprite);
        }
        else
        {
            displayItem[3].gameObject.SetActive(false);
        }

        //display 4
        if (turn_i < upgradeComponentTurn.Length)
        {
            UpgradeComponent comp = null;
            comp = upgradeComponentTurn[turn_i];
            displayItem[4].ChangeItem(comp.name, comp.cost, comp.sprite);
        }
        else
        {
            displayItem[4].gameObject.SetActive(false);
        }
    }
    public void UpDamage() {
        int cost = int.Parse(displayItem[0].textCost.text);
        if (GameManager.CanBuy(cost)){
            GameManager.Buy(cost);
            //if we can buy it we buy it
            upgradeComponentDamage[dmg_i].CallOtherFunctions();
            dmg_i++;
            UpdateDisplay();
        }
    }
    public void UpFire()
    {
        int cost = int.Parse(displayItem[1].textCost.text);
        if (GameManager.CanBuy(cost))
        {
            GameManager.Buy(cost);
            //if we can buy it we buy it
            upgradeComponentFire[fire_i].CallOtherFunctions();
            fire_i++;
            UpdateDisplay();
        }
    }
    public void UpPool()
    {
        int cost = int.Parse(displayItem[2].textCost.text);
        if (GameManager.CanBuy(cost))
        {
            GameManager.Buy(cost);
            //if we can buy it we buy it
            upgradeComponentEnPool[enPool_i].CallOtherFunctions();
            enPool_i++;
            UpdateDisplay();
        }
    }
    public void UpRate()
    {
        int cost = int.Parse(displayItem[3].textCost.text);
        if (GameManager.CanBuy(cost))
        {
            GameManager.Buy(cost);
            //if we can buy it we buy it
            upgradeComponentEnRate[enRate_i].CallOtherFunctions();
            enRate_i++;
            UpdateDisplay();
        }
    }
    public void UpTurn()
    {
        int cost = int.Parse(displayItem[4].textCost.text);
        if (GameManager.CanBuy(cost))
        {
            GameManager.Buy(cost);
            //if we can buy it we buy it
            upgradeComponentTurn[turn_i].CallOtherFunctions();
            turn_i++;
            UpdateDisplay();
        }
    }


}
