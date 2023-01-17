using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject BlockManager;

    void Update()
    {
        BlockManager.GetComponent<BlockManager>().Place(isGhost: true);

        if (Input.GetMouseButtonDown(0)) BlockManager.GetComponent<BlockManager>().Place(isGhost: false);
    }

    public Vector3 SnapToGrid(Vector3 rawPosition)
    {
        Vector3 snapped = new Vector3(0.5f, rawPosition.y + 0.5f, 0.5f);
        snapped.x = Mathf.Round(rawPosition.x - 0.5f) + snapped.x;
        snapped.z = Mathf.Round(rawPosition.z - 0.5f) + snapped.z;

        return snapped;
    }
}
