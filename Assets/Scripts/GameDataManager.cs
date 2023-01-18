using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;

    private int score;

    internal static GameDataManager instance;

    public BlockType selectedBlockType { get; set; } = BlockType.MULTIPLY;

    public void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) selectBlockType(BlockType.MULTIPLY);
        if (Input.GetKeyDown(KeyCode.P)) selectBlockType(BlockType.PLUS);
    }

    public BlockType selectBlockType(BlockType blockType)
    {
        selectedBlockType = blockType;
        BlockManager.instance.ghostBlockDirty = true;

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
