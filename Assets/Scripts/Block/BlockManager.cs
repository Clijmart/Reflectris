using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager instance;

    [Header("Block Audio")]
    [SerializeField] private float blockErrorSoundVolume = 1f;
    [SerializeField] private AudioClip[] blockErrorSounds;
    [SerializeField] private float blockPlaceSoundVolume = 1f;
    [SerializeField] private AudioClip[] blockPlaceSounds;

    [Header("Layers")]
    [SerializeField] private LayerMask solidLayer;
    [SerializeField] private LayerMask floorLayer;

    public List<Block> placedBlocks = new();

    private GameObject ghostBlock;
    private bool ghostBlockDirty = true;

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Place a block on the grid.
    /// </summary>
    /// <param name="isGhost">Whether or not the placed block should be ghost variant.</param>
    public void Place(bool isGhost)
    {
        if (!GameManager.instance.IsRunning() && !GameManager.instance.IsStarting()) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 200.0f, floorLayer))
        {
            Vector3 placePosition = GridController.instance.SnapToGrid(rawPosition: hit.point);

            if (isGhost) PlaceGhost(placePosition);
            else PlaceBlock(placePosition);
        }
    }

    /// <summary>
    /// Place a block at a given position.
    /// </summary>
    /// <param name="placePosition">Position to place the block at.</param>
    public void PlaceBlock(Vector3 placePosition)
    {
        BlockType selectedBlockType = GameDataManager.instance.GetSelectedBlockType();
        if (!ObjectiveManager.instance.FitsObjective(blockType: selectedBlockType))
        {
            AudioManager.instance.PlayRandomSound(audioClips: blockErrorSounds, volume: blockErrorSoundVolume);
            return;
        }

        GameObject prefab = IBlockType.blockTypeObjects[selectedBlockType].BlockPrefab();
        if (WillCollide(parentPrefab: prefab, placePosition)) return;

        AudioManager.instance.PlayRandomSound(audioClips: blockPlaceSounds, volume: blockPlaceSoundVolume);

        int selectedBlockRotation = GameDataManager.instance.GetSelectedBlockRotation();
        Instantiate(prefab, placePosition, Quaternion.Euler(new Vector3(0f, selectedBlockRotation, 0f)));

        MakeGhostBlockDirty();

        ObjectiveManager.instance.NewObjective();
    }

    /// <summary>
    /// Place a ghost block at a given position.
    /// </summary>
    /// <param name="placePosition">Position to place the ghost block at.</param>
    public void PlaceGhost(Vector3 placePosition)
    {
        if (!ghostBlockDirty && (ghostBlock == null || placePosition == ghostBlock.transform.position)) return;
        Destroy(ghostBlock);

        GameObject prefab = IBlockType.blockTypeObjects[GameDataManager.instance.GetSelectedBlockType()].GhostBlockPrefab();
        bool willCollide = WillCollide(parentPrefab: prefab, placePosition);

        int selectedBlockRotation = GameDataManager.instance.GetSelectedBlockRotation();
        ghostBlock = Instantiate(prefab, placePosition, Quaternion.Euler(new Vector3(0f, selectedBlockRotation, 0f)));

        ghostBlock.gameObject.GetComponent<GhostBlock>().Colliding(colliding: willCollide);

        ghostBlockDirty = false;
    }

    /// <summary>
    /// Checks if the child objects of given prefab will collide with other objects.
    /// </summary>
    /// <param name="parentPrefab">Parent prefab to check collision on.</param>
    /// <param name="placePosition">Position to check collision at.</param>
    /// <returns>Whether or not there were any collisions.</returns>
    private bool WillCollide(GameObject parentPrefab, Vector3 placePosition)
    {
        int selectedBlockRotation = GameDataManager.instance.GetSelectedBlockRotation();
        parentPrefab.transform.rotation = Quaternion.Euler(new Vector3(0f, selectedBlockRotation, 0f));
        foreach (Transform child in parentPrefab.transform)
        {
            if (Physics.CheckSphere(placePosition + child.position, 0.1f, solidLayer)) return true;
        }
        return false;
    }

    /// <summary>
    /// Mark the ghost block as dirty, so it will be replaced next Update cycle.
    /// </summary>
    public void MakeGhostBlockDirty()
    {
        ghostBlockDirty = true;
    }

    /// <summary>
    /// Destroy all placed blocks and empty the list.
    /// </summary>
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