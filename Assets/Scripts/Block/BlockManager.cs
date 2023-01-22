using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager instance;

    public List<Block> placedBlocks = new();

    [Header("Block Audio")]
    [SerializeField]
    private float blockErrorSoundVolume = 1f;
    [SerializeField]
    private AudioClip[] blockErrorSounds;
    [SerializeField]
    private float blockPlaceSoundVolume = 1f;
    [SerializeField]
    private AudioClip[] blockPlaceSounds;

    [Header("Layers")]
    [SerializeField]
    private LayerMask solidLayer;
    [SerializeField]
    private LayerMask floorLayer;

    private GameObject ghostBlock;
    private bool ghostBlockDirty = true;

    private void Awake()
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
        BlockType selectedBlockType = GameDataManager.instance.GetSelectedBlockType();
        if (!ObjectiveManager.instance.FitsObjective(selectedBlockType))
        {
            AudioManager.instance.PlayRandomSound(blockErrorSounds, blockErrorSoundVolume);
            return;
        }

        GameObject prefab = IBlockType.blockTypeObjects[selectedBlockType].BlockPrefab();
        if (WillCollide(prefab, placePosition)) return;

        AudioManager.instance.PlayRandomSound(blockPlaceSounds, blockPlaceSoundVolume);
        Instantiate(prefab, placePosition, Quaternion.identity);

        MakeGhostBlockDirty();

        ObjectiveManager.instance.NewObjective();
    }

    public void PlaceGhost(Vector3 placePosition)
    {
        if (!ghostBlockDirty && (ghostBlock == null || placePosition == ghostBlock.transform.position)) return;
        Destroy(ghostBlock);

        GameObject prefab = IBlockType.blockTypeObjects[GameDataManager.instance.GetSelectedBlockType()].GhostBlockPrefab();
        bool willCollide = WillCollide(prefab, placePosition);

        ghostBlock = Instantiate(prefab, placePosition, Quaternion.identity);

        ghostBlock.gameObject.GetComponent<GhostBlock>().Colliding(willCollide);

        ghostBlockDirty = false;
    }

    private bool WillCollide(GameObject parentPrefab, Vector3 placePosition)
    {
        foreach (Transform child in parentPrefab.transform)
        {
            if (Physics.CheckSphere(placePosition + child.position, 0.1f, solidLayer)) return true;
        }
        return false;
    }

    public void MakeGhostBlockDirty()
    {
        ghostBlockDirty = true;
    }

    public void DestroyAllBlocks()
    {
        for (int i = placedBlocks.Count - 1; i >= 0; i--)
        {
            if (placedBlocks[i] != null)
            {
                Destroy(placedBlocks[i].gameObject);
            }
        }

        placedBlocks.Clear();
    }
}
