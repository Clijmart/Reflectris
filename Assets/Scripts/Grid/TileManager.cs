using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> floorPrefabs;

    [SerializeField]
    private List<GameObject> borderPrefabs;

    public GameObject Place(GridController grid, int col, int row, string tileType)
    {
        GameObject tilePrefab = new();

        if (tileType.Equals("Border"))
        {
            tilePrefab = borderPrefabs[row == -1 || row == grid.gridHeight ? 0 : 1];
        }
        else if (tileType.Equals("Floor"))
        {
            tilePrefab = floorPrefabs[(row % floorPrefabs.Count + col % floorPrefabs.Count) % floorPrefabs.Count];
        }

        int startRowPosition = grid.gridHeight / -2;
        int startColPosition = grid.gridWidth / -2;

        Vector3 pos = new(startColPosition + col, grid.gameObject.transform.position.y, startRowPosition + row);

        GameObject tile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation, grid.gameObject.transform);
        tile.name = string.Format("Tile {0}_{1}", col, row);

        return tile;
    }
}
