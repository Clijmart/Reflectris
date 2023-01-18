using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;

    public BlockType selectedBlockType { get; set; } = BlockType.MULTIPLY;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) selectedBlockType = BlockType.MULTIPLY;
        if (Input.GetKeyDown(KeyCode.P)) selectedBlockType = BlockType.PLUS;
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
}
