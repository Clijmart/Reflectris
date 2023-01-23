using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private List<BlockWall> blockWalls;

    private void Start()
    {
        BlockManager.instance.placedBlocks.Add(this);
    }

    private void Update()
    {
        if (blockWalls.Count <= 0)
        {
            // Does this work?
            BlockManager.instance.placedBlocks.Remove(this);
            Destroy(gameObject);
        }
    }

    public void RemoveBlockWall(BlockWall blockWall)
    {
        blockWalls.Remove(blockWall);
    }
}
