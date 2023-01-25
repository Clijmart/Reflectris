using UnityEngine;

public class SettingsManager : MonoBehaviour, ISaveable
{
    public static SettingsManager instance;

    public float volume;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
        SaveDataManager.AddSaveable(saveableType: "Settings", saveable: instance);
    }

    /// <summary>
    /// Populate the save data with settings data.
    /// </summary>
    /// <param name="saveData">Save data to populate.</param>
    public void PopulateSaveData(SaveData saveData)
    {
        saveData.settingsData.volume = volume;
    }

    /// <summary>
    /// Load settings data from save data.
    /// </summary>
    /// <param name="saveData">Save data to load from.</param>
    public void LoadFromSaveData(SaveData saveData)
    {
        volume = saveData.settingsData.volume;
    }
}
