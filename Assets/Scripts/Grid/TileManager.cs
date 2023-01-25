using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    [Header("Floor Prefabs")]
    [SerializeField] private List<GameObject> floorPrefabs;

    [Header("Border Prefabs")]
    [SerializeField] private GameObject leftBorderPrefab;
    [SerializeField] private GameObject rightBorderPrefab;
    [SerializeField] private GameObject topBorderPrefab;
    [SerializeField] private GameObject bottomBorderPrefab;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Place a tile of a given tile type at a grid cell.
    /// </summary>
    /// <param name="gridCell">The grid cell to place the tile at.</param>
    /// <param name="tileType">The tile type to place.</param>
    /// <returns>The object of the placed tile.</returns>
    public GameObject PlaceTile(Vector2Int gridCell, string tileType)
    {
        if (tileType.Equals("Floor")) return PlaceFloorTile(gridCell);
        return PlaceBorderTile(gridCell);
    }

    /// <summary>
    /// Place a floor tile at a grid cell.
    /// </summary>
    /// <param name="gridCell">The grid cell to place the floor tile at.</param>
    /// <returns>The object of the placed floor tile.</returns>
    public GameObject PlaceFloorTile(Vector2Int gridCell)
    {
        Vector3 tilePosition = GridController.instance.CellToPosition(gridCell);
        GameObject floorTilePrefab = floorPrefabs[(gridCell.y % floorPrefabs.Count + gridCell.x % floorPrefabs.Count) % floorPrefabs.Count];

        GameObject tile = Instantiate(floorTilePrefab, tilePosition, floorTilePrefab.transform.rotation, GridController.instance.gameObject.transform);
        tile.name = $"Floor {gridCell.x}_{gridCell.y}";

        return floorTilePrefab;
    }

    /// <summary>
    /// Place a border tile at a grid cell.
    /// </summary>
    /// <param name="gridCell">The grid cell to place the border tile at.</param>
    /// <returns>The object of the placed border tile.</returns>
    public GameObject PlaceBorderTile(Vector2Int gridCell)
    {
        Vector3 tilePosition = GridController.instance.CellToPosition(gridCell);
        GameObject borderTilePrefab;

        if (gridCell.y == GridController.instance.GetGridSize().y) borderTilePrefab = topBorderPrefab;
        else if (gridCell.x == -1) borderTilePrefab = leftBorderPrefab;
        else if (gridCell.x == GridController.instance.GetGridSize().x) borderTilePrefab = rightBorderPrefab;
        else if (gridCell.y == -1) borderTilePrefab = bottomBorderPrefab;
        else borderTilePrefab = topBorderPrefab;

        GameObject tile = Instantiate(borderTilePrefab, tilePosition, borderTilePrefab.transform.rotation, GridController.instance.gameObject.transform);
        tile.name = $"Border {gridCell.x}_{gridCell.y}";

        return borderTilePrefab;
    }
}