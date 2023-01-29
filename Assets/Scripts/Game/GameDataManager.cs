using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    [Header("Game Data Defaults")]
    [SerializeField] private int startLives = 2;
    [SerializeField] private int maxLives = 3;
    [SerializeField] private BlockType selectedBlockType = BlockType.MULTIPLICATION;

    private static int FULL_ROTATION = 360;

    private float gameLength;
    private int lives, score, selectedBlockRotation;

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
        lives = startLives;
        LivesManager.instance.DrawLives();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        if (lives <= 0 && GameManager.instance.IsRunning())
        {
            GameManager.instance.EndGame(instant: false);
        }

        if (GameManager.instance.IsRunning())
        {
            gameLength += Time.deltaTime;
        }
    }

    /// <summary>
    /// Get the selected block type.
    /// </summary>
    /// <returns>The selected block type.</returns>
    public BlockType GetSelectedBlockType()
    {
        return selectedBlockType;
    }

    /// <summary>
    /// Select a block type.
    /// </summary>
    /// <param name="blockType">The block type to select.</param>
    public void SetSelectedBlockType(BlockType blockType)
    {
        selectedBlockType = blockType;
        ResetSelectedBlockRotation();
    }

    /// <summary>
    /// Cycle to another block type by a given amount.
    /// </summary>
    /// <param name="cycleAmount">The amount of block types to cycle through.</param>
    /// <returns>The new block type.</returns>
    public BlockType ChangeSelectedBlockType(int cycleAmount)
    {
        BlockType nextBlockType = IBlockType.RelaviteBlockType(currentBlockType: GetSelectedBlockType(), relativeAmount: cycleAmount);
        SetSelectedBlockType(blockType: nextBlockType);

        return nextBlockType;
    }

    /// <summary>
    /// Get the selected block rotation.
    /// </summary>
    /// <returns>The select block rotation.</returns>
    public int GetSelectedBlockRotation()
    {
        return selectedBlockRotation;
    }

    /// <summary>
    /// Reset the selected block rotation and mark ghost as dirty.
    /// </summary>
    public void ResetSelectedBlockRotation()
    {
        selectedBlockRotation = 0;
        BlockManager.instance.MakeGhostBlockDirty();
    }
    
    /// <summary>
    /// Change the selected block rotation and mark ghost as dirty.
    /// </summary>
    /// <param name="rotationChange">The amount the block should be rotated.</param>
    /// <returns>The new block rotation.</returns>
    public int ChangeSelectedBlockRotation(int rotationChange)
    {
        selectedBlockRotation = (selectedBlockRotation + rotationChange + FULL_ROTATION) % FULL_ROTATION;
        BlockManager.instance.MakeGhostBlockDirty();
        return selectedBlockRotation;
    }

    /// <summary>
    /// Get the max amount of lives.
    /// </summary>
    /// <returns>The max amount of lives.</returns>
    public int MaxLives()
    {
        return maxLives;
    }

    /// <summary>
    /// Get the current amount of lives.
    /// </summary>
    /// <returns>The current amount of lives.</returns>
    public int Lives()
    {
        return lives;
    }

    /// <summary>
    /// Change the amount of lives by a given amount.
    /// </summary>
    /// <param name="amount">The amount the lives should be changed with.</param>
    /// <returns>The new amount of lives.</returns>
    public int ChangeLives(int amount)
    {
        lives = Mathf.Min(lives + amount, maxLives);

        LivesManager.instance.DrawLives();
        return lives;
    }

    /// <summary>
    /// Get the current score.
    /// </summary>
    /// <returns>The current score.</returns>
    public int Score()
    {
        return score;
    }

    /// <summary>
    /// Change the score by a given amount.
    /// </summary>
    /// <param name="amount">The amount the score should be changed with.</param>
    /// <returns>The new score.</returns>
    public int ChangeScore(int amount)
    {
        score += amount;
        return score;
    }

    /// <summary>
    /// Get the time the game has been going for in seconds.
    /// </summary>
    /// <returns>The amount of seconds the game has been going for.</returns>
    public float GameLength()
    {
        return gameLength;
    }
}