using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] blockErrorSounds;
    [SerializeField]
    private AudioClip[] blockPlaceSounds;

    [SerializeField]
    private LayerMask solidLayer;
    [SerializeField]
    private LayerMask floorLayer;

    private GameObject ghostBlock;

    public bool ghostBlockDirty = true;

    public static BlockManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void Place(bool isGhost)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 200.0f, floorLayer))
        {
            Vector3 placePosition = GridController.instance.SnapToGrid(rawPosition: hit.point);

            if (isGhost) PlaceGhost(placePosition);
            else PlaceBlock(placePosition);
        }
    }

    public void PlaceBlock(Vector3 placePosition)
    {
        BlockType selectedBlockType = GameDataManager.instance.selectedBlockType;
        if (!ObjectiveManager.instance.FitsObjective(selectedBlockType))
        {
            AudioManager.instance.PlayRandomSound(blockErrorSounds);
            return;
        }

        GameObject prefab = IBlockType.blockTypes[selectedBlockType].BlockPrefab();
        if (WillCollide(prefab, placePosition)) return;

        AudioManager.instance.PlayRandomSound(blockPlaceSounds);
        Instantiate(prefab, placePosition, Quaternion.identity);
        ghostBlockDirty = true;

        ObjectiveManager.instance.NewObjective();
    }

    public void PlaceGhost(Vector3 placePosition)
    {
        if (!ghostBlockDirty && (ghostBlock == null || placePosition == ghostBlock.transform.position)) return;
        Destroy(ghostBlock);

        GameObject prefab = IBlockType.blockTypes[GameDataManager.instance.selectedBlockType].GhostBlockPrefab();
        bool willCollide = WillCollide(prefab, placePosition);

        ghostBlock = Instantiate(prefab, placePosition, Quaternion.identity);

        ghostBlock.gameObject.GetComponent<GhostBlock>().Colliding(willCollide);

        ghostBlockDirty = false;
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
