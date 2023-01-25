using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour, ISaveable
{
    public static StatisticsManager instance;

    public int bestScore;
    public int totalScore;
    public int plays;
    public float bestTime;
    public float totalTime;

    private void Awake()
    {
        instance = this;
        SaveDataManager.AddSaveable("Statistics", instance);
    }

    private void Start()
    {
        SaveDataManager.LoadJsonData();
    }

    public void SaveGame()
    {
        SaveDataManager.LoadJsonData();

        int gameScore = GameDataManager.instance.Score();
        if (gameScore > bestScore) bestScore = gameScore;
        
        totalScore += gameScore;
        
        plays++;

        float gameTime = GameDataManager.instance.GameLength();
        if (gameTime > bestTime) bestTime = gameTime;

        totalTime += gameTime;

        SaveDataManager.SaveJsonData();
    }

    public void PopulateSaveData(SaveData saveData)
    {
        saveData.statisticsData.bestScore = bestScore;
        saveData.statisticsData.totalScore = totalScore;
        saveData.statisticsData.plays = plays;
        saveData.statisticsData.bestTime = bestTime;
        saveData.statisticsData.totalTime = totalTime;
    }

    public void LoadFromSaveData(SaveData saveData)
    {
        bestScore = saveData.statisticsData.bestScore;
        totalScore = saveData.statisticsData.totalScore;
        plays = saveData.statisticsData.plays;
        bestTime = saveData.statisticsData.bestTime;
        totalTime = saveData.statisticsData.totalTime;
    }
}
