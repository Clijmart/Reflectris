using UnityEngine;
using TMPro;

public class GameUIController : MenuUI
{
    [Header("Countdown UI")]
    [SerializeField] private TextMeshProUGUI countdownText;

    [Header("Stats UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameLengthText;

    [Header("Objective UI")]
    [SerializeField] private TextMeshProUGUI equationText;

    [Header("Pause UI")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI pauseButtonText;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI summaryScoreText;
    [SerializeField] private TextMeshProUGUI summaryBonusScoreText;
    [SerializeField] private TextMeshProUGUI summaryFinalScoreText;
    [SerializeField] private TextMeshProUGUI summaryBestScoreText;
    [SerializeField] private TextMeshProUGUI summaryTimeText;
    [SerializeField] private TextMeshProUGUI summaryBestTimeText;

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
        // Game Over
        gameOverPanel.SetActive(GameManager.instance.IsGameOver());
        if (GameManager.instance.IsGameOver())
        {
            // Score
            int gameScore = GameDataManager.instance.Score();
            int bonusScore = Mathf.FloorToInt(GameDataManager.instance.GameLength());
            int finalScore = gameScore + bonusScore;

            summaryScoreText.text = $"Game: {gameScore}";
            summaryBonusScoreText.text = $"Time bonus: {bonusScore}";
            summaryFinalScoreText.text = $"Total: {finalScore}";

            int bestScore = StatisticsManager.instance.bestScore;
            if (finalScore >= bestScore)
                summaryBestScoreText.text = "NEW BEST SCORE!";
            else
                summaryBestScoreText.text = $"Best: {bestScore}";

            // Time
            float gameTime = GameDataManager.instance.GameLength();
            summaryTimeText.text = $"Game: {TimeUtil.FormattedTime(Mathf.FloorToInt(gameTime), false)}";

            float bestTime = StatisticsManager.instance.bestTime;
            if (gameTime >= bestTime)
                summaryBestTimeText.text = "NEW BEST TIME!";
            else
                summaryBestTimeText.text = $"Best: {TimeUtil.FormattedTime(Mathf.FloorToInt(bestTime), false)}";
        }
        
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
        scoreText.text = $"{GameDataManager.instance.Score()} Score";
        gameLengthText.text = TimeUtil.FormattedTime(timeInSeconds: Mathf.FloorToInt(GameDataManager.instance.GameLength()), includeHours: false);

        // Objective
        equationText.text = ObjectiveManager.instance.CurrentObjective().GetEquation();
    }

    /// <summary>
    /// Go to the main menu screen.
    /// </summary>
    public void GoToMenu()
    {
        if (GameManager.instance.IsGameOver())
        {
            GameManager.instance.LeaveGame();
            return;
        }

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