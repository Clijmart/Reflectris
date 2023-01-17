using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tilePrefabs;

    public GameObject Place(GridController grid, int col, int row)
    {
        int startRowPosition = grid.gridHeight / -2;
        int startColPosition = grid.gridWidth / -2;

        GameObject tilePrefab = tilePrefabs[(row % tilePrefabs.Count + col % tilePrefabs.Count) % tilePrefabs.Count];

        Vector3 pos = new Vector3(startRowPosition + row, grid.gameObject.transform.position.y, startColPosition + col);

        GameObject tile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation, transform);
        tile.name = string.Format("Tile {0}-{1}", col, row);

        return tile;
    }
}
