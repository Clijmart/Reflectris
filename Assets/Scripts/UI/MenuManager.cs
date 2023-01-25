using UnityEngine.SceneManagement;

public class MenuManager
{
    public static void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void OpenGameMenu()
    {
        SceneManager.LoadScene(1);
    }

    public static void OpenStatisticsMenu()
    {
        SceneManager.LoadScene(2);
    }

    public static void OpenSettingsMenu()
    {
        SceneManager.LoadScene(3);
    }
}