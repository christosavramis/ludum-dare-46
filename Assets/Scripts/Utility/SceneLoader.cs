using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public static void Ending()
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        Debug.Log("menu");
        SceneManager.LoadScene(0);
    }
    
    public static void EndingLose()
    {
        SceneManager.LoadScene(3);
    }
}
