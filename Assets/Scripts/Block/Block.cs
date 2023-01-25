using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Block Options")]
    [SerializeField] private List<BlockWall> blockWalls;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        BlockManager.instance.placedBlocks.Add(this);
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        if (blockWalls.Count <= 0) Remove();
    }

    /// <summary>
    /// Destroy the block and remove it from the list.
    /// </summary>
    public void Remove()
    {
        BlockManager.instance.placedBlocks.Remove(this);
        Destroy(gameObject);
    }

    /// <summary>
    /// Remove a wall from the block.
    /// </summary>
    /// <param name="blockWall">The wall to remove from the block.</param>
    public void RemoveBlockWall(BlockWall blockWall)
    {
        blockWalls.Remove(blockWall);
    }
}