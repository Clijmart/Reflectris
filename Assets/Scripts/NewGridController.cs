using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGridController : MonoBehaviour
{
    [SerializeField]
    private int gridHeight = 9;
    [SerializeField]
    private int gridWidth = 9;

    [SerializeField]
    private List<GameObject> tilePrefabs;

    void Start()
    {
        int startRowPosition = gridHeight / -2;
        int startColPosition = gridWidth / -2;

        for(int row = 0; row < gridHeight; row++)
        {
            for (int col = 0; col < gridWidth; col++)
            {
                GameObject tilePrefab = tilePrefabs[(row % tilePrefabs.Count + col % tilePrefabs.Count) % tilePrefabs.Count];

                Vector3 pos = new Vector3(startRowPosition + row, transform.position.y, startColPosition + col);
                GameObject tile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation, transform);
                tile.name = string.Format("Tile {0}-{1}", col, row);
            }
        }
    }
}
