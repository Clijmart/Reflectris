using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUIController : MenuUI
{
    private void Start()
    {
        SettingsManager.instance.LoadSettings();

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().PlayMusic();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            SceneManager.instance.StartGame();
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            SceneManager.instance.OpenStats();
        }
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals))
        {
            SceneManager.instance.OpenSettings();
        }
    }
}
