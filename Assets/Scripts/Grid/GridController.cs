using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridController : MonoBehaviour
{
    public static GridController instance;

    [Header("Grid Options")]
    [SerializeField] private Vector2Int gridSize = new(9, 9);

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        GenerateGrid();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        BlockManager.instance.Place(isGhost: true);
    }

    /// <summary>
    /// Generate the grid and place the tiles.
    /// </summary>
    private void GenerateGrid()
    {
        for (int y = -1; y < gridSize.y + 1; y++)
        {
            for (int x = -1; x < gridSize.x + 1; x++)
            {
                if (y >= 0 && y < gridSize.y && x >= 0 && x < gridSize.x)
                {
                    TileManager.instance.PlaceTile(gridCell: new Vector2Int(x, y), tileType: "Floor");
                } else
                {
                    TileManager.instance.PlaceTile(gridCell: new Vector2Int(x, y), tileType: "Border");
                }
            }
        }
    }

    /// <summary>
    /// Get a random grid cell.
    /// </summary>
    /// <returns>A random grid cell</returns>
    public Vector2Int RandomGridCell()
    {
        int x = Random.Range(0, gridSize.x);
        int y = Random.Range(0, gridSize.y);

        return new Vector2Int(x, y);
    }

    /// <summary>
    /// Get multiple unique random grid cells.
    /// </summary>
    /// <param name="cellAmount">The amount of grid cells to get.</param>
    /// <param name="bordered">Whether or not the random grid cells should be away from the edges.</param>
    /// <returns>Unique random grid cells.</returns>
    public List<Vector2Int> RandomGridCells(int cellAmount, bool bordered)
    {
        List<Vector2Int> gridCells = new();
        List<Vector2Int> tempCells = new();
        int borderedInt = bordered ? 1 : 0;

        // Add all grid cells to a temporary list
        for (int x = 0 + borderedInt; x < gridSize.x - borderedInt; x++)
        {
            for (int y = 0 + borderedInt; y < gridSize.y - borderedInt; y++)
            {
                tempCells.Add(new Vector2Int(x, y));
            }
        }

        // Get a random cell each time and remove it from the temporary list
        for (int i = 0; i < cellAmount; i++)
        {
            int cell = Random.Range(0, tempCells.Count);

            gridCells.Add(tempCells[cell]);
            tempCells.RemoveAt(cell);
        }

        return gridCells;
    }

    /// <summary>
    /// Get the world position of a grid cell.
    /// </summary>
    /// <param name="gridCell">The grid cell to get the position of.</param>
    /// <returns>The position of the grid cell.</returns>
    public Vector3 CellToPosition(Vector2Int gridCell)
    {
        return new(GetGridSize().x / -2 + gridCell.x, GetGridPosition().y, GetGridSize().y / -2 + gridCell.y);
    }

    /// <summary>
    /// Snap a position to neat grid coordinates.
    /// </summary>
    /// <param name="rawPosition">The position to snap.</param>
    /// <returns>A rounded new position that fits the grid.</returns>
    public Vector3 SnapToGrid(Vector3 rawPosition)
    {
        Vector3 snapped = new(0.5f, rawPosition.y + 0.5f, 0.5f);
        snapped.x = Mathf.Round(rawPosition.x - 0.5f) + snapped.x;
        snapped.z = Mathf.Round(rawPosition.z - 0.5f) + snapped.z;

        return snapped;
    }

    /// <summary>
    /// Get the position of the grid.
    /// </summary>
    /// <returns>The position of the grid.</returns>
    public Vector3 GetGridPosition()
    {
        return transform.position;
    }

    /// <summary>
    /// Get the size of the grid.
    /// </summary>
    /// <returns>The size of the grid.</returns>
    public Vector2Int GetGridSize()
    {
        return gridSize;
    }
}