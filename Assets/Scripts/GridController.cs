using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]
    private GameObject placeBlock;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click detected");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 200.0f))
            {
                if (!hit.transform.gameObject.CompareTag("Grid")) return;

                Vector3 spawnPosition = new Vector3(0.5f, hit.point.y + 0.5f, 0.5f);
                spawnPosition.x = Mathf.Round(hit.point.x - 0.5f) + spawnPosition.x;
                spawnPosition.z = Mathf.Round(hit.point.z - 0.5f) + spawnPosition.z;
                Instantiate(placeBlock, spawnPosition, Quaternion.identity);
                Debug.Log("You clicked the " + hit.transform.name);
            }
        }
    }
}
