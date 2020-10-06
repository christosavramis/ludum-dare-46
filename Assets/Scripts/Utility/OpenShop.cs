using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    public GameObject canva;
    public static bool GameIsPause = false;
    public void CloseShopWindow()
    {
        GameIsPause = false;
        canva.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OpenShopWindow()
    {
        Time.timeScale = 0f;
        GameIsPause = true;
        canva.SetActive(true);
    }
}
