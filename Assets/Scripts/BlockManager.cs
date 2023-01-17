using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Grid;

    [SerializeField]
    private GameObject blockFrefab;
    [SerializeField]
    private GameObject ghostPrefab;

    [SerializeField]
    private LayerMask solidLayer;

    private GameObject ghostBlock;

    public void Place(bool isGhost)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 200.0f))
        {
            if (!hit.transform.gameObject.CompareTag("Grid")) return;

            Vector3 placePosition = Grid.GetComponent<GridController>().SnapToGrid(rawPosition: hit.point);

            if (isGhost) PlaceGhost(placePosition);
            else PlaceBlock(placePosition);
        }
    }

    public void PlaceBlock(Vector3 placePosition)
    {
        if (WillCollide(blockFrefab, placePosition)) return;

        Instantiate(blockFrefab, placePosition, Quaternion.identity);
    }

    public void PlaceGhost(Vector3 placePosition)
    {
        bool willCollide = WillCollide(ghostPrefab, placePosition);

        if (ghostBlock != null)
        {
            if (placePosition == ghostBlock.transform.position && ghostBlock.gameObject.GetComponent<Block>().Colliding() == willCollide) return;

            Destroy(ghostBlock);
        }

        ghostBlock = Instantiate(ghostPrefab, placePosition, Quaternion.identity);

        ghostBlock.gameObject.GetComponent<Block>().Colliding(willCollide);
    }

    bool WillCollide(GameObject parentPrefab, Vector3 placePosition)
    {
        foreach (Transform child in parentPrefab.transform)
        {
            if (Physics.CheckSphere(placePosition + child.position, 0.1f, solidLayer)) return true;
        }
        return false;
    }
}
