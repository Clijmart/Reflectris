using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    [Header("Data Defaults")]
    [SerializeField]
    private int startLives = 3;
    [SerializeField]
    private int maxLives = 3;
    [SerializeField]
    private int score = 0;

    private float gameLength = 0;
    private int lives;

    private BlockType selectedBlockType = BlockType.MULTIPLICATION;
    private int selectedBlockRotation = 0;
    private int FULL_ROTATION = 360;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        lives = startLives;
    }

    private void Update()
    {
        if (lives <= 0)
        {
            GameManager.instance.EndGame();
        }

        if (GameManager.instance.IsRunning())
        {
            gameLength += Time.deltaTime;
        }
    }

    public BlockType GetSelectedBlockType()
    {
        return selectedBlockType;
    }

    public void SetSelectedBlockType(BlockType blockType)
    {
        selectedBlockType = blockType;
        ResetSelectedBlockRotation();
    }

    public BlockType ChangeSelectedBlockType(int cycleAmount)
    {
        BlockType nextBlockType = IBlockType.RelaviteBlockType(GetSelectedBlockType(), cycleAmount);
        SetSelectedBlockType(nextBlockType);

        return nextBlockType;
    }

    public int GetSelectedBlockRotation()
    {
        return selectedBlockRotation;
    }

    public void ResetSelectedBlockRotation()
    {
        selectedBlockRotation = 0;
        BlockManager.instance.MakeGhostBlockDirty();
    }
    
    public int ChangeSelectedBlockRotation(int rotationChange)
    {
        selectedBlockRotation = (selectedBlockRotation + rotationChange + FULL_ROTATION) % FULL_ROTATION;
        BlockManager.instance.MakeGhostBlockDirty();
        return selectedBlockRotation;
    }

    public int Lives()
    {
        return lives;
    }

    public int ChangeLives(int amount)
    {
        lives = Mathf.Min(lives + amount, maxLives);
        return lives;
    }

    public int Score()
    {
        return score;
    }

    public int ChangeScore(int amount)
    {
        score += amount;
        return score;
    }

    public float GameLength()
    {
        return gameLength;
    }
}
