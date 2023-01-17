using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private BlockManager BlockManager;

    [SerializeField]
    private TileManager TileManager;

    [SerializeField]
    public int gridHeight = 9;
    [SerializeField]
    public int gridWidth = 9;

    void Start()
    {
        GenerateGrid();
    }

    void Update()
    {
        BlockManager.Place(isGhost: true);

        if (Input.GetMouseButtonDown(0)) BlockManager.Place(isGhost: false);
    }

    private void GenerateGrid()
    {
        for (int row = -1; row < gridHeight + 1; row++)
        {
            for (int col = -1; col < gridWidth + 1; col++)
            {
                if (row >= 0 && row < gridHeight && col >= 0 && col < gridWidth)
                {
                    TileManager.Place(this, col, row, "Floor");
                } else
                {
                    TileManager.Place(this, col, row, "Border");
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
}
