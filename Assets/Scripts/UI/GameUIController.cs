using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countdownText;

    [Header("Stats UI")]
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI gameLengthText;

    [Header("Objective UI")]
    [SerializeField]
    private TextMeshProUGUI equationText;

    private void Update()
    {
        // Countdown
        if (GameManager.instance.IsStarting())
        {
            countdownText.text = $"{Mathf.CeilToInt(GameManager.instance.GetCountdown())}";
        } else
        {
            countdownText.text = "";
        }

        // Stats
        livesText.text = $"{GameDataManager.instance.Lives()} Lives";
        scoreText.text = $"{GameDataManager.instance.Score()} Score";
        gameLengthText.text = FormattedTime(Mathf.RoundToInt(GameDataManager.instance.GameLength()));

        // Objective
        equationText.text = ObjectiveManager.instance.CurrentObjective().GetEquation();
    }

    public void LeaveGame()
    {
        GameManager.instance.EndGame();
    }

    public void PauseGame()
    {
        GameManager.instance.PauseGame();
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
