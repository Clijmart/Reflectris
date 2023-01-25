using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsUIController : MenuUI
{
    [Header("Settings UI")]
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private TextMeshProUGUI volumeText;

    private void Start()
    {
        SettingsManager.instance.LoadSettings();

        volumeSlider.value = GetVolume(); ;

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().PlayMusic();
    }

    private void Update()
    {
        volumeText.text = $"{GetVolume()}%";
    }

    public float GetVolume()
    {
        return SettingsManager.instance.volume * 100f;
    }

    public void UpdateVolume()
    {
        float volumePercentage = volumeSlider.value;
        SettingsManager.instance.volume = volumePercentage / 100f;
    }

    public void SaveSettings()
    {
        SettingsManager.instance.SaveSettings();
    }
}
