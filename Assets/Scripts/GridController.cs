using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject blockFrefab;

    [SerializeField]
    private GameObject ghostPrefab;

    [SerializeField]
    private LayerMask solidLayer;

    private GameObject ghostBlock;

    void Update()
    {
        PlaceGhost();

        if (Input.GetMouseButtonDown(0))
        {
            PlaceBlock();
        }
    }

    void PlaceBlock()
    {
        Debug.Log("Click detected");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 200.0f))
        {
            if (!hit.transform.gameObject.CompareTag("Grid")) return;

            Vector3 spawnPosition = SnapToGrid(hit.point);

            // ToDo: Replace with collide check for each separate wall piece!
            bool willCollide = Physics.CheckSphere(spawnPosition, 0.5f, solidLayer);
            if (willCollide)
            {
                Debug.Log("Can't place!");
                return;
            }

            Instantiate(blockFrefab, spawnPosition, Quaternion.identity);
            Debug.Log("You clicked the " + hit.transform.name);
        }
    }

    void PlaceGhost()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 200.0f))
        {
            if (!hit.transform.gameObject.CompareTag("Grid")) return;

            Vector3 spawnPosition = SnapToGrid(hit.point);

            // ToDo: Replace with collide check for each separate wall piece!
            bool willCollide = Physics.CheckSphere(spawnPosition, 0.5f, solidLayer);
            if (willCollide) return;

            if (ghostBlock != null)
            {
                if (spawnPosition == ghostBlock.transform.position) return;

                Destroy(ghostBlock);
            }

            ghostBlock = Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 SnapToGrid(Vector3 rawPosition)
    {
        Vector3 snapped = new Vector3(0.5f, rawPosition.y + 0.5f, 0.5f);
        snapped.x = Mathf.Round(rawPosition.x - 0.5f) + snapped.x;
        snapped.z = Mathf.Round(rawPosition.z - 0.5f) + snapped.z;

        return snapped;
    }
}
