using UnityEngine;
using TMPro;

public class GameUIController : MenuUI
{
    [Header("Countdown UI")]
    [SerializeField] private TextMeshProUGUI countdownText;

    [Header("Stats UI")]
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameLengthText;

    [Header("Objective UI")]
    [SerializeField] private TextMeshProUGUI equationText;

    [Header("Pause UI")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI pauseButtonText;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        SaveDataManager.LoadJsonData();

        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudioController>().ReplayMusic();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        // Pause
        pausePanel.SetActive(GameManager.instance.IsPaused());
        pauseButtonText.text = GameManager.instance.IsPaused() ? "Resume" : "Pause";

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
        gameLengthText.text = TimeUtil.FormattedTime(timeInSeconds: Mathf.RoundToInt(GameDataManager.instance.GameLength()), includeHours: false);

        // Objective
        equationText.text = ObjectiveManager.instance.CurrentObjective().GetEquation();
    }

    /// <summary>
    /// Go to the main menu screen.
    /// </summary>
    public void GoToMenu()
    {
        GameManager.instance.EndGame(instant: true);
    }

    /// <summary>
    /// Pause the game.
    /// </summary>
    public void PauseGame()
    {
        GameManager.instance.PauseGame();
    }
}