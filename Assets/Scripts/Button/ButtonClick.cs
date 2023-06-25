using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    public void StartButton()
    {
        Loading.LoadScene("DesertMap");
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("GameStartScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("DesertMap");
    }
    

}
