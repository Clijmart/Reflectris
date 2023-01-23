using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    [Header("Floor Prefabs")]

    [SerializeField]
    private List<GameObject> floorPrefabs;

    [Header("Border Prefabs")]
    [SerializeField]
    private GameObject leftBorderPrefab;
    [SerializeField]
    private GameObject rightBorderPrefab;
    [SerializeField]
    private GameObject topBorderPrefab;
    [SerializeField]
    private GameObject bottomBorderPrefab;

    private void Awake()
    {
        instance = this;
    }

    public GameObject PlaceTile(Vector2Int gridCell, string tileType)
    {
        GameObject tilePrefab;

        if (tileType.Equals("Floor"))
        {
            tilePrefab = floorPrefabs[(gridCell.y % floorPrefabs.Count + gridCell.x % floorPrefabs.Count) % floorPrefabs.Count];
        }
        else
        {
            if (gridCell.y == GridController.instance.GetGridSize().y) tilePrefab = topBorderPrefab;
            else if (gridCell.x == -1) tilePrefab = leftBorderPrefab;
            else if (gridCell.x == GridController.instance.GetGridSize().x) tilePrefab = rightBorderPrefab;
            else if (gridCell.y == -1) tilePrefab = bottomBorderPrefab;

            else tilePrefab = topBorderPrefab;
        }

        Vector3 pos = GridController.instance.CellToPosition(gridCell);
        GameObject tile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation, GridController.instance.gameObject.transform);
        tile.name = $"Tile {gridCell.x}_{gridCell.y}";

        return tile;
    }
}
