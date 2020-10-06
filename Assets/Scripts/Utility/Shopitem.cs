using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shopitem : MonoBehaviour
{
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textCost;
    public Image sprite;
    public void ChangeItem(string textName, int cost, Sprite sprite)
    {
        this.textName.text = textName;
        this.sprite.sprite = sprite;
        this.textCost.text = cost.ToString();
    }
}
