using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour, ISaveable
{
    public static SettingsManager instance;

    public float volume;

    private void Awake()
    {
        instance = this;
        SaveDataManager.AddSaveable("Settings", instance);
    }

    public void LoadSettings()
    {
        SaveDataManager.LoadJsonData();
    }

    public void SaveSettings()
    {
        SaveDataManager.SaveJsonData();
    }

    public void PopulateSaveData(SaveData saveData)
    {
        saveData.settingsData.volume = volume;
    }

    public void LoadFromSaveData(SaveData saveData)
    {
        volume = saveData.settingsData.volume;
    }
}
