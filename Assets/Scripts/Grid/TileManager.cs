using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    [Header("Tile Prefabs")]
    [SerializeField]
    private List<GameObject> floorPrefabs;
    [SerializeField]
    private List<GameObject> borderPrefabs;

    private void Awake()
    {
        instance = this;
    }

    public GameObject PlaceTile(int col, int row, string tileType)
    {
        GameObject tilePrefab;

        if (tileType.Equals("Floor"))
        {
            tilePrefab = floorPrefabs[(row % floorPrefabs.Count + col % floorPrefabs.Count) % floorPrefabs.Count];
        }
        else
        {
            tilePrefab = borderPrefabs[row == -1 || row == GridController.instance.GetGridSize().y ? 0 : 1];
        }

        int startRowPosition = GridController.instance.GetGridSize().y / -2;
        int startColPosition = GridController.instance.GetGridSize().x / -2;
        
        Vector3 pos = new(startColPosition + col, GridController.instance.GetGridPosition().y, startRowPosition + row);

        GameObject tile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation, GridController.instance.gameObject.transform);
        tile.name = string.Format("Tile {0}_{1}", col, row);

        return tile;
    }
}
