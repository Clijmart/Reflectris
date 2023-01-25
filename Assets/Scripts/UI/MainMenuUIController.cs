using UnityEngine;

public class MainMenuUIController : MenuUI
{
    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        SaveDataManager.LoadJsonData();

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().PlayMusic();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        ReadUserInput();
    }

    /// <summary>
    /// Read the user inputs.
    /// </summary>
    private void ReadUserInput()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            MenuManager.OpenGameMenu();
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            MenuManager.OpenStatisticsMenu();
        }
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals))
        {
            MenuManager.OpenSettingsMenu();
        }
    }
}