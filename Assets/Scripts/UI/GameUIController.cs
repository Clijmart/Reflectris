using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [Header("Stats UI")]
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI gameLengthText;
    [SerializeField]
    private TextMeshProUGUI ballSpeedText;

    [Header("Objective UI")]
    [SerializeField]
    private TextMeshProUGUI equationText;

    private void Update()
    {
        // Stats
        livesText.text = string.Format("{0} Lives", GameDataManager.instance.Lives());
        scoreText.text = string.Format("{0} Score", GameDataManager.instance.Score());
        gameLengthText.text = FormattedTime(Mathf.RoundToInt(GameDataManager.instance.GameLength()));

        // Objective
        equationText.text = ObjectiveManager.instance.CurrentObjective().GetEquation();
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
