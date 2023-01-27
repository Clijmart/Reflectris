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
        SaveDataManager.LoadJsonData();

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudioController>().PlayMusic();
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
        bestTimeText.text = $"Best: {TimeUtil.FormattedTime(timeInSeconds: Mathf.FloorToInt(StatisticsManager.instance.bestTime), includeHours: false)}";
        totalTimeText.text = $"Total: {TimeUtil.FormattedTime(timeInSeconds: Mathf.FloorToInt(StatisticsManager.instance.totalTime), includeHours: true)}";
    }
}