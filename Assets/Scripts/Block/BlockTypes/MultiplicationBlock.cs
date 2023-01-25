using UnityEngine;

public class MultiplicationBlock : MonoBehaviour, IBlockType
{
    [Header("Block Prefabs")]
    [SerializeField] private GameObject ghostBlockPrefab;
    [SerializeField] private GameObject blockPrefab;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        IBlockType.blockTypeObjects.Add(GetBlockType(), this);
    }

    /// <summary>
    /// Get the Ghost Block Prefab of the block.
    /// </summary>
    /// <returns>A GameObject of the Ghost Block Prefab.</returns>
    public GameObject GhostBlockPrefab()
    {
        return ghostBlockPrefab;
    }

    /// <summary>
    /// Get the Block Prefab of the block.
    /// </summary>
    /// <returns>A GameObject of the Block Prefab.</returns>
    public GameObject BlockPrefab()
    {
        return blockPrefab;
    }

    /// <summary>
    /// Get the Block Type of the block.
    /// </summary>
    /// <returns>The matching BlockType</returns>
    public BlockType GetBlockType()
    {
        return BlockType.MULTIPLICATION;
    }

    /// <summary>
    /// Generate terms that fit the block.
    /// </summary>
    /// <param name="amount">The amount of terms to generate.</param>
    /// <returns>An array of terms.</returns>
    public int[] GenerateTerms(int amount)
    {
        int[] terms = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            terms[i] = Random.Range(1, 5);
        }

        return terms;
    }

    /// <summary>
    /// Apply the matching arithmetic operator on given terms.
    /// </summary>
    /// <param name="terms">The terms to apply the operator on.</param>
    /// <returns>The result after the operator has been applied.</returns>
    public float ApplyOperator(int[] terms)
    {
        float solution = 1;
        for (int i = 0; i < terms.Length; i++)
        {
            solution = terms[i] * solution;
        }

        return solution;
    }
}