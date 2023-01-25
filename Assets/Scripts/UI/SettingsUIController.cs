using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsUIController : MenuUI
{
    [Header("Settings UI")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI volumeText;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        SaveDataManager.LoadJsonData();

        volumeSlider.value = GetVolume();

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().PlayMusic();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        volumeText.text = $"{GetVolume()}%";
    }

    /// <summary>
    /// Get the volume as a percentage
    /// </summary>
    /// <returns>The selected audio volume.</returns>
    public float GetVolume()
    {
        return SettingsManager.instance.volume * 100f;
    }

    /// <summary>
    /// Update the selected volume using the slider input.
    /// </summary>
    public void UpdateVolume()
    {
        float volumePercentage = volumeSlider.value;
        SettingsManager.instance.volume = volumePercentage / 100f;
    }

    /// <summary>
    /// Save the selected settings.
    /// </summary>
    public void SaveSettings()
    {
        SaveDataManager.SaveJsonData();
    }
}