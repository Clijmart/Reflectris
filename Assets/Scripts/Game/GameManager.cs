using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameState gameState;

    [SerializeField]
    private float startCountdownLength = 5f;
    [SerializeField]
    private float endCountdownLength = 5f;

    private float countdown;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartGame();
    }

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

    public float GetCountdown()
    {
        return countdown;
    }

    private void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
    }

    private GameState GetGameState()
    {
        return gameState;
    }

    public void StartGame()
    {
        countdown = startCountdownLength;
        PlayerManager.instance.SpawnPlayerBall();

        SetGameState(GameState.STARTING);
    }

    public void RunGame()
    {
        SetGameState(GameState.RUNNING);
    }

    public void PauseGame()
    {
        if (IsRunning()) SetGameState(GameState.PAUSED);
        else if (IsPaused()) RunGame();
    }

    public void EndGame(bool instant)
    {
        if (IsEnding()) return;

        StatisticsManager.instance.SaveGame();

        if (instant)
        {
            LeaveGame();
            return;
        }

        countdown = endCountdownLength;
        SetGameState(GameState.ENDING);
    }

    public void LeaveGame()
    {
        IBlockType.blockTypeObjects.Clear();
        IItemType.itemTypeObjects.Clear();

        MenuManager.OpenMainMenu();
    }

    public bool IsStarting()
    {
        return GetGameState() == GameState.STARTING;
    }

    public bool IsRunning()
    {
        return GetGameState() == GameState.RUNNING;
    }

    public bool IsPaused()
    {
        return GetGameState() == GameState.PAUSED;
    }

    public bool IsEnding()
    {
        return GetGameState() == GameState.ENDING;
    }
}

public enum GameState
{
    STARTING,
    RUNNING,
    PAUSED,
    ENDING,
}
