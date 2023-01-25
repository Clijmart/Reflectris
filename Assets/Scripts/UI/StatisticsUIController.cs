using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticsUIController : MenuUI
{
    [Header("Stats UI")]
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMeshProUGUI totalScoreText;
    [SerializeField]
    private TextMeshProUGUI playsText;
    [SerializeField]
    private TextMeshProUGUI bestTimeText;
    [SerializeField]
    private TextMeshProUGUI totalTimeText;

    private void Start()
    {
        SettingsManager.instance.LoadSettings();

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().PlayMusic();
    }

    private void Update()
    {
        // Stats
        bestScoreText.text = $"Best: {StatisticsManager.instance.bestScore}";
        totalScoreText.text = $"Total: {StatisticsManager.instance.totalScore}";
        playsText.text = $"Plays: {StatisticsManager.instance.plays}";
        bestTimeText.text = $"Best: {FormattedTime(Mathf.RoundToInt(StatisticsManager.instance.bestTime))}";
        totalTimeText.text = $"Total: {FormattedTime(Mathf.RoundToInt(StatisticsManager.instance.totalTime))}";
    }

    // Made using https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html
    private string FormattedTime(int timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60F);
        int seconds = Mathf.FloorToInt(timeInSeconds - minutes * 60);
        string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        return formattedTime;
    }
}
