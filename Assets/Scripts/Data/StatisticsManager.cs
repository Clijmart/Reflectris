using UnityEngine;

public class StatisticsManager : MonoBehaviour, ISaveable
{
    public static StatisticsManager instance;

    public int bestScore, totalScore, plays;
    public float bestTime, totalTime;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
        SaveDataManager.AddSaveable(saveableType: "Statistics", saveable: instance);
    }

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        SaveDataManager.LoadJsonData();
    }

    /// <summary>
    /// Save a game's statistics.
    /// </summary>
    public void SaveGame()
    {
        SaveDataManager.LoadJsonData();

        int gameScore = GameDataManager.instance.Score();
        int bonusScore = Mathf.RoundToInt(GameDataManager.instance.GameLength());
        gameScore += bonusScore;

        if (gameScore > bestScore) bestScore = gameScore;
        
        totalScore += gameScore;
        
        plays++;

        float gameTime = GameDataManager.instance.GameLength();
        if (gameTime > bestTime) bestTime = gameTime;

        totalTime += gameTime;

        SaveDataManager.SaveJsonData();
    }

    /// <summary>
    /// Populate the save data with statistics data.
    /// </summary>
    /// <param name="saveData">Save data to populate.</param>
    public void PopulateSaveData(SaveData saveData)
    {
        saveData.statisticsData.bestScore = bestScore;
        saveData.statisticsData.totalScore = totalScore;
        saveData.statisticsData.plays = plays;
        saveData.statisticsData.bestTime = bestTime;
        saveData.statisticsData.totalTime = totalTime;
    }

    /// <summary>
    /// Load statistics data from save data.
    /// </summary>
    /// <param name="saveData">Save data to load from.</param>
    public void LoadFromSaveData(SaveData saveData)
    {
        bestScore = saveData.statisticsData.bestScore;
        totalScore = saveData.statisticsData.totalScore;
        plays = saveData.statisticsData.plays;
        bestTime = saveData.statisticsData.bestTime;
        totalTime = saveData.statisticsData.totalTime;
    }
}