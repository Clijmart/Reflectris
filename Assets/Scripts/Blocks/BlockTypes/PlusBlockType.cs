using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusBlockType : MonoBehaviour, IBlockType
{
    [SerializeField]
    private GameObject ghostBlockPrefab;

    [SerializeField]
    private GameObject blockPrefab;

    private void Start()
    {
        IBlockType.blockTypes.Add(GetBlockType(), this);
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
        return global::BlockType.PLUS;
    }
}
