using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonBack()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtonAbout()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonQuit()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }
}
