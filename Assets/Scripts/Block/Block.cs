using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private List<BlockWall> blockWalls;

    private void Update()
    {
        if (blockWalls.Count <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void RemoveBlockWall(BlockWall blockWall)
    {
        blockWalls.Remove(blockWall);
    }
}
