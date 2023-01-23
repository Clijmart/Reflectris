using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridController : MonoBehaviour
{
    public static GridController instance;

    [SerializeField]
    private Vector2Int gridSize = new(9, 9);

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
        for (int y = -1; y < gridSize.y + 1; y++)
        {
            for (int x = -1; x < gridSize.x + 1; x++)
            {
                if (y >= 0 && y < gridSize.y && x >= 0 && x < gridSize.x)
                {
                    TileManager.instance.PlaceTile(new Vector2Int(x, y), "Floor");
                } else
                {
                    TileManager.instance.PlaceTile(new Vector2Int(x, y), "Border");
                }
            }
        }
    }

    public Vector2Int RandomGridCell()
    {
        int x = Random.Range(0, gridSize.x);
        int y = Random.Range(0, gridSize.y);

        return new Vector2Int(x, y);
    }

    public List<Vector2Int> RandomGridCells(int cellAmount)
    {
        List<Vector2Int> gridCells = new();
        List<Vector2Int> tempCells = new();

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                tempCells.Add(new Vector2Int(x, y));
            }
        }

        for (int i = 0; i < cellAmount; i++)
        {
            int cell = Random.Range(0, tempCells.Count);

            gridCells.Add(tempCells[cell]);
            tempCells.RemoveAt(cell);
        }

        return gridCells;
    }

    public Vector3 CellToPosition(Vector2Int gridCell)
    {
        return new(GetGridSize().x / -2 + gridCell.x, GetGridPosition().y, GetGridSize().y / -2 + gridCell.y);
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

    public Vector2Int GetGridSize()
    {
        return gridSize;
    }
}
