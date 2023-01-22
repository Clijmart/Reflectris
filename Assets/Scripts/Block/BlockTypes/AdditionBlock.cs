using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionBlock : MonoBehaviour, IBlockType
{
    [SerializeField]
    private GameObject ghostBlockPrefab;

    [SerializeField]
    private GameObject blockPrefab;

    private void Start()
    {
        IBlockType.blockTypeObjects.Add(GetBlockType(), this);
    }

    public GameObject GhostBlockPrefab()
    {
        return ghostBlockPrefab;
    }
    public GameObject BlockPrefab()
    {
        return blockPrefab;
    }

    public BlockType GetBlockType()
    {
        return global::BlockType.ADDITION;
    }

    public int[] GenerateTerms(int amount)
    {
        int[] terms = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            terms[i] = Random.Range(1, 5);
        }

        return terms;
    }

    public float ApplyOperator(int[] terms)
    {
        float solution = 0;
        for (int i = 0; i < terms.Length; i++)
        {
            solution = terms[i] + solution;
        }

        return solution;
    }
}
