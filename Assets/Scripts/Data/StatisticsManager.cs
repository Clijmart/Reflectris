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
    }

    private void Start()
    {
        LoadJsonData(instance);
    }

    public void SaveGame()
    {
        LoadJsonData(instance);

        int gameScore = GameDataManager.instance.Score();
        if (gameScore > bestScore) bestScore = gameScore;
        
        totalScore += gameScore;
        
        plays++;

        float gameTime = GameDataManager.instance.GameLength();
        if (gameTime > bestTime) bestTime = gameTime;

        totalTime += gameTime;

        SaveJsonData(instance);
    }

    public void PopulateSaveData(SaveData saveData)
    {
        saveData.statisticsData.bestScore = bestScore;
        saveData.statisticsData.totalScore = totalScore;
        saveData.statisticsData.plays = plays;
        saveData.statisticsData.bestTime = bestTime;
        saveData.statisticsData.totalTime = totalTime;
    }

    private static void SaveJsonData(StatisticsManager statisticsManager)
    {
        SaveData saveData = new SaveData();
        statisticsManager.PopulateSaveData(saveData);

        if (FileManager.WriteToFile("SaveData.dat", saveData.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    public void LoadFromSaveData(SaveData saveData)
    {
        bestScore = saveData.statisticsData.bestScore;
        totalScore = saveData.statisticsData.totalScore;
        plays = saveData.statisticsData.plays;
        bestTime = saveData.statisticsData.bestTime;
    }

    private static void LoadJsonData(StatisticsManager statisticsManager)
    {
        if (FileManager.LoadFromFile("SaveData.dat", out var json))
        {
            SaveData saveData = new SaveData();
            saveData.LoadFromJson(json);

            statisticsManager.LoadFromSaveData(saveData);
            Debug.Log("Load complete");
        }
    }
}
