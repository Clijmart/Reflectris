using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractionBlock : MonoBehaviour, IBlockType
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
        return global::BlockType.SUBTRACTION;
    }

    public int[] GenerateTerms(int amount)
    {
        int[] terms = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            terms[i] = Random.Range(1, 5);
        }

        int allAdded = 0;
        for (int i = 0; i < terms.Length; i++)
        {
            allAdded += terms[i];
        }

        terms[0] = allAdded;

        return terms;
    }

    public float ApplyOperator(int[] terms)
    {
        float solution = terms[0];
        for (int i = 1; i < terms.Length; i++)
        {
            solution -= terms[i];
        }

        return solution;
    }
}
