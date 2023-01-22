using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IBlockType
{
    public static Dictionary<BlockType, IBlockType> blockTypeObjects = new();

    public abstract GameObject GhostBlockPrefab();
    public abstract GameObject BlockPrefab();

    public abstract BlockType GetBlockType();

    public abstract int[] GenerateTerms(int amount);

    public abstract float ApplyOperator(int[] terms);

    public static IBlockType RandomBlockType()
    {
        List<IBlockType> blockTypes = Enumerable.ToList(blockTypeObjects.Values);
        return blockTypes[Random.Range(0, blockTypes.Count)];
    }

    public static IBlockType GetFromType(BlockType blockType)
    {
        return blockTypeObjects[blockType];
    }

    public static BlockType RelaviteBlockType(BlockType currentBlockType, int relativeAmount)
    {
        BlockType[] blockTypes = (BlockType[]) System.Enum.GetValues(typeof(BlockType));
        int wanted = (System.Array.IndexOf(blockTypes, currentBlockType) + relativeAmount + blockTypes.Length) % blockTypes.Length;

        return blockTypes[wanted];
    }
}

public enum BlockType
{
    ADDITION,
    SUBTRACTION,
    MULTIPLICATION,
    DIVISION,
}