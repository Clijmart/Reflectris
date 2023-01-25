using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IBlockType
{
    public static Dictionary<BlockType, IBlockType> blockTypeObjects = new();

    /// <summary>
    /// Get the Ghost Block Prefab of the block.
    /// </summary>
    /// <returns>A GameObject of the Ghost Block Prefab.</returns>
    public abstract GameObject GhostBlockPrefab();

    /// <summary>
    /// Get the Block Prefab of the block.
    /// </summary>
    /// <returns>A GameObject of the Block Prefab.</returns>
    public abstract GameObject BlockPrefab();

    /// <summary>
    /// Get the Block Type of the block.
    /// </summary>
    /// <returns>The matching BlockType</returns>
    public abstract BlockType GetBlockType();

    /// <summary>
    /// Generate terms that fit the block.
    /// </summary>
    /// <param name="amount">The amount of terms to generate.</param>
    /// <returns>An array of terms.</returns>
    public abstract int[] GenerateTerms(int amount);

    /// <summary>
    /// Apply the matching arithmetic operator on given terms.
    /// </summary>
    /// <param name="terms">The terms to apply the operator on.</param>
    /// <returns>The result after the operator has been applied.</returns>
    public abstract float ApplyOperator(int[] terms);

    /// <summary>
    /// Get a random Block Type object.
    /// </summary>
    /// <returns>A Block Type object.</returns>
    public static IBlockType RandomBlockType()
    {
        List<IBlockType> blockTypes = Enumerable.ToList(blockTypeObjects.Values);
        return blockTypes[Random.Range(0, blockTypes.Count)];
    }

    /// <summary>
    /// Get the Block Type object matching a Block Type.
    /// </summary>
    /// <param name="blockType">The Block Type to find the object with.</param>
    /// <returns>A Block Type object.</returns>
    public static IBlockType GetFromType(BlockType blockType)
    {
        return blockTypeObjects[blockType];
    }

    /// <summary>
    /// Find the Block Type relative to the given Block Type by a certain amount.
    /// </summary>
    /// <param name="currentBlockType">The Block Type to relate with.</param>
    /// <param name="relativeAmount">The amount relative amount of steps away from the given Block Type.</param>
    /// <returns>A Block Type.</returns>
    public static BlockType RelaviteBlockType(BlockType currentBlockType, int relativeAmount)
    {
        BlockType[] blockTypes = (BlockType[]) System.Enum.GetValues(typeof(BlockType));
        int wanted = (System.Array.IndexOf(blockTypes, currentBlockType) + relativeAmount + blockTypes.Length) % blockTypes.Length;

        return blockTypes[wanted];
    }
}
