using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController instance;

    [SerializeField]
    private int2 gridSize = new(9, 9);

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateGrid();
    }

    private void Update()
    {
        BlockManager.instance.Place(isGhost: true);
    }

    private void GenerateGrid()
    {
        for (int row = -1; row < gridSize.y + 1; row++)
        {
            for (int col = -1; col < gridSize.x + 1; col++)
            {
                if (row >= 0 && row < gridSize.y && col >= 0 && col < gridSize.x)
                {
                    TileManager.instance.PlaceTile(col, row, "Floor");
                } else
                {
                    TileManager.instance.PlaceTile(col, row, "Border");
                }
            }
        }
    }

    public Vector3 SnapToGrid(Vector3 rawPosition)
    {
        Vector3 snapped = new Vector3(0.5f, rawPosition.y + 0.5f, 0.5f);
        snapped.x = Mathf.Round(rawPosition.x - 0.5f) + snapped.x;
        snapped.z = Mathf.Round(rawPosition.z - 0.5f) + snapped.z;

        return snapped;
    }

    public Vector3 GetGridPosition()
    {
        return transform.position;
    }

    public int2 GetGridSize()
    {
        return gridSize;
    }
}
