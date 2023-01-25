using UnityEngine;

// Made using https://youtu.be/uD7y4T4PVk0
[System.Serializable]
public class SaveData
{
    [System.Serializable]
    public struct StatisticsData
    {
        public int bestScore;
        public int totalScore;
        public int plays;
        public float bestTime;
        public float totalTime;
    }

    [System.Serializable]
    public struct SettingsData
    {
        public float volume;
    }

    public StatisticsData statisticsData;
    public SettingsData settingsData;
    
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}

public interface ISaveable
{
    void PopulateSaveData(SaveData saveData);
    void LoadFromSaveData(SaveData saveData);
}
