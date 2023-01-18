using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockType
{
    public static Dictionary<BlockType, IBlockType> blockTypes = new();

    public abstract GameObject GhostBlockPrefab();
    public abstract GameObject BlockPrefab();

    public abstract BlockType GetBlockType();
}

public enum BlockType
{
    MULTIPLY,
    PLUS
}