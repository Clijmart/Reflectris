using UnityEngine;

public class MainMenuUIController : MenuUI
{
    [SerializeField] private GameObject guidePanel;

    private bool guideOpen = false;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        SaveDataManager.LoadJsonData();

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudioController>().PlayMusic();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        guidePanel.SetActive(guideOpen);

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

    /// <summary>
    /// Open the guide panel.
    /// </summary>
    public void OpenGuide()
    {
        guideOpen = true;
    }

    /// <summary>
    /// Close the guide panel.
    /// </summary>
    public void CloseGuide()
    {
        guideOpen = false;
    }

    /// <summary>
    /// Check if the guide panel is open.
    /// </summary>
    /// <returns></returns>
    public bool IsGuideOpen()
    {
        return guideOpen;
    }
}