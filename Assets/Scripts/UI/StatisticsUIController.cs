using UnityEngine;
using TMPro;

public class StatisticsUIController : MenuUI
{
    [Header("Stats UI")]
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI playsText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    [SerializeField] private TextMeshProUGUI totalTimeText;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        SettingsManager.instance.LoadSettings();

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().PlayMusic();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        // Stats
        bestScoreText.text = $"Best: {StatisticsManager.instance.bestScore}";
        totalScoreText.text = $"Total: {StatisticsManager.instance.totalScore}";
        playsText.text = $"Plays: {StatisticsManager.instance.plays}";
        bestTimeText.text = $"Best: {FormattedTime(Mathf.RoundToInt(StatisticsManager.instance.bestTime))}";
        totalTimeText.text = $"Total: {FormattedTime(Mathf.RoundToInt(StatisticsManager.instance.totalTime))}";
    }

    /// <summary>
    /// Turn time into a nicely formatted string.
    /// </summary>
    /// <param name="timeInSeconds">Time in seconds.</param>
    /// <returns>A formatted string.</returns>
    private string FormattedTime(int timeInSeconds)
    {
        // Made with the help of https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html
        int hours = Mathf.FloorToInt(timeInSeconds / 3600f);
        int minutes = Mathf.FloorToInt((timeInSeconds - hours * 3600) / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds - hours * 3600 - minutes * 60);
        string formattedTime = $"{hours:00}:{minutes:00}:{seconds:00}";
        //string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        return formattedTime;
    }
}
