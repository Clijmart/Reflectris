using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void OpenMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OpenStats()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void OpenSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
