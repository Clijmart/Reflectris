using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionBlock : MonoBehaviour, IBlockType
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
        return global::BlockType.DIVISION;
    }

    public int[] GenerateTerms(int amount)
    {
        int[] terms = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            terms[i] = Random.Range(1, 5);
        }

        int allMultiplied = 1;
        for (int i = 0; i < terms.Length; i++)
        {
            allMultiplied = terms[i] * allMultiplied;
        }

        terms[0] = allMultiplied;

        return terms;
    }

    public float ApplyOperator(int[] terms)
    {
        float solution = terms[0];
        for (int i = 1; i < terms.Length; i++)
        {
            solution /= terms[i];
        }

        return solution;
    }
}
