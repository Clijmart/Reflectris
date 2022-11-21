using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void OpenMain()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenStats()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(3);
    }
}
