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
        for (int row = 0; row < gridHeight; row++)
        {
            for (int col = 0; col < gridWidth; col++)
            {
                TileManager.Place(this, col, row);
            }
        }
    }

    void Update()
    {
        BlockManager.Place(isGhost: true);

        if (Input.GetMouseButtonDown(0)) BlockManager.Place(isGhost: false);
    }

    public Vector3 SnapToGrid(Vector3 rawPosition)
    {
        Vector3 snapped = new Vector3(0.5f, rawPosition.y + 0.5f, 0.5f);
        snapped.x = Mathf.Round(rawPosition.x - 0.5f) + snapped.x;
        snapped.z = Mathf.Round(rawPosition.z - 0.5f) + snapped.z;

        return snapped;
    }
}
