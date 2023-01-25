using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Countdowns")]
    [SerializeField] private float startCountdownLength = 5f;
    [SerializeField] private float endCountdownLength = 5f;

    private GameState gameState;
    private float countdown;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        StartGame();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            return;
        }

        if (IsStarting())
        {
            RunGame();
        } else if (IsEnding())
        {
            LeaveGame();
        }
    }

    /// <summary>
    /// Get the current countdown value.
    /// </summary>
    /// <returns>The current countdown.</returns>
    public float GetCountdown()
    {
        return countdown;
    }

    /// <summary>
    /// Set the game state.
    /// </summary>
    /// <param name="gameState">The state to set the game to.</param>
    private void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
    }

    /// <summary>
    /// Get the game state.
    /// </summary>
    /// <returns>The state of the game.</returns>
    private GameState GetGameState()
    {
        return gameState;
    }

    /// <summary>
    /// Start the pregame and spawns the player.
    /// </summary>
    public void StartGame()
    {
        countdown = startCountdownLength;
        PlayerManager.instance.SpawnPlayerBall();

        SetGameState(GameState.STARTING);
    }

    /// <summary>
    /// End the pregame and run the main game.
    /// </summary>
    public void RunGame()
    {
        SetGameState(GameState.RUNNING);
    }

    /// <summary>
    /// Toggle the pause state of the game.
    /// </summary>
    public void PauseGame()
    {
        if (IsRunning())
        {
            SetGameState(GameState.PAUSED);
            GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().PauseMusic();
        }
        else if (IsPaused())
        {
            SetGameState(GameState.RUNNING);
            GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().UnPauseMusic();
        }
    }

    /// <summary>
    /// End the main game either instantly or start the endgame countdown.
    /// </summary>
    /// <param name="instant">Whether or not the game should end instantly.</param>
    public void EndGame(bool instant)
    {
        if (IsEnding()) return;

        StatisticsManager.instance.SaveGame();
        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<BackgroundAudio>().StopMusic();

        if (instant)
        {
            LeaveGame();
            return;
        }

        countdown = endCountdownLength;
        SetGameState(GameState.ENDING);
    }

    /// <summary>
    /// Leave the game by clearing object lists and go to the main menu.
    /// </summary>
    public void LeaveGame()
    {
        IBlockType.blockTypeObjects.Clear();
        IItemType.itemTypeObjects.Clear();

        MenuManager.OpenMainMenu();
    }

    /// <summary>
    /// Checks if the game is starting.
    /// </summary>
    /// <returns>Whether or not the game is starting.</returns>
    public bool IsStarting()
    {
        return GetGameState() == GameState.STARTING;
    }

    /// <summary>
    /// Checks if the game is running.
    /// </summary>
    /// <returns>Whether or not the game is running.</returns>
    public bool IsRunning()
    {
        return GetGameState() == GameState.RUNNING;
    }

    /// <summary>
    /// Checks if the game is paused.
    /// </summary>
    /// <returns>Whether or not the game is paused.</returns>
    public bool IsPaused()
    {
        return GetGameState() == GameState.PAUSED;
    }

    /// <summary>
    /// Checks if the game is ending.
    /// </summary>
    /// <returns>Whether or not the game is ending.</returns>
    public bool IsEnding()
    {
        return GetGameState() == GameState.ENDING;
    }
}