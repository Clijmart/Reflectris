using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip clickSound;

    /// <summary>
    /// Play a click sound.
    /// </summary>
    public void PlayClickSound()
    {
        AudioManager.instance.PlaySound(audioClip: clickSound, volume: 0.5f);
    }
    
    /// <summary>
    /// Open main menu.
    /// </summary>
    public void OpenMainMenu()
    {
        MenuManager.OpenMainMenu();
    }

    /// <summary>
    /// Open game menu.
    /// </summary>
    public void OpenGameMenu()
    {
        MenuManager.OpenGameMenu();
    }

    /// <summary>
    /// Open statistics menu.
    /// </summary>
    public void OpenStatisticsMenu()
    {
        MenuManager.OpenStatisticsMenu();
    }

    /// <summary>
    /// Open settings menu.
    /// </summary>
    public void OpenSettingsMenu()
    {
        MenuManager.OpenSettingsMenu();
    }
}