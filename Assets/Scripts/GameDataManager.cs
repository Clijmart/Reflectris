using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    [Header("Data Defaults")]
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private int score = 0;

    private BlockType selectedBlockType = BlockType.MULTIPLY;

    private void Awake()
    {
        instance = this;
    }

    public BlockType GetSelectedBlockType()
    {
        return selectedBlockType;
    }

    public BlockType SetSelectedBlockType(BlockType blockType)
    {
        selectedBlockType = blockType;
        BlockManager.instance.MakeGhostBlockDirty();

        return selectedBlockType;
    }

    public int Lives()
    {
        return lives;
    }

    public int ChangeLives(int amount)
    {
        lives += amount;
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
}
