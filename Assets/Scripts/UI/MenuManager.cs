using UnityEngine.SceneManagement;

public class MenuManager
{
    /// <summary>
    /// Open main menu.
    /// </summary>
    public static void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Open game menu.
    /// </summary>
    public static void OpenGameMenu()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Open statistics menu.
    /// </summary>
    public static void OpenStatisticsMenu()
    {
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Open settings menu.
    /// </summary>
    public static void OpenSettingsMenu()
    {
        SceneManager.LoadScene(3);
    }
}