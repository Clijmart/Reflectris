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
    }

    public void LoadSettings()
    {
        LoadJsonData(instance);
    }

    public void SaveSettings()
    {
        SaveJsonData(instance);
    }

    public void PopulateSaveData(SaveData saveData)
    {
        saveData.settingsData.volume = volume;
    }

    private static void SaveJsonData(SettingsManager settingsManager)
    {
        SaveData saveData = new();
        settingsManager.PopulateSaveData(saveData);

        if (FileManager.WriteToFile("SaveData.dat", saveData.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    public void LoadFromSaveData(SaveData saveData)
    {
        volume = saveData.settingsData.volume;
    }

    private static void LoadJsonData(SettingsManager settingsManager)
    {
        if (FileManager.LoadFromFile("SaveData.dat", out var json))
        {
            SaveData saveData = new();
            saveData.LoadFromJson(json);

            settingsManager.LoadFromSaveData(saveData);
            Debug.Log("Load complete");
        }
    }
}
