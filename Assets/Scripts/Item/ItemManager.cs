using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    [Header("Item Options")]
    [SerializeField] private int itemCount = 3;

    public List<Item> spawnedItems = new();

    /// <summary>
    /// Called when the instance is being loaded.
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        SpawnItems();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        if (spawnedItems.Count == 0)
        {
            SpawnItems();
        }
    }

    /// <summary>
    /// Despawn all existing items and respawn them.
    /// </summary>
    public void RespawnAllItems()
    {
        DespawnAllItems();
        SpawnItems();
    }

    /// <summary>
    /// Spawn an item at a position.
    /// </summary>
    /// <param name="itemType">The type of item to spawn.</param>
    /// <param name="spawnPosition">The position to spawn the item at.</param>
    public void Spawn(IItemType itemType, Vector3 spawnPosition)
    {
        GameObject prefab = itemType.ItemPrefab();

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    /// <summary>
    /// Spawn multiple items on the grid.
    /// </summary>
    public void SpawnItems()
    {
        if (!GameManager.instance.IsRunning()) return;

        List<Vector2Int> gridCells = GridController.instance.RandomGridCells(cellAmount: itemCount, bordered: true);
        foreach (Vector2Int gridCell in gridCells)
        {
            Vector3 cellPosition = GridController.instance.CellToPosition(gridCell);
            Spawn(itemType: IItemType.RandomItemType(), spawnPosition: cellPosition);
        }
    }

    /// <summary>
    /// Despawn all existing items and remove them from the list.
    /// </summary>
    public void DespawnAllItems()
    {
        for (int i = spawnedItems.Count - 1; i >= 0; i--)
        {
            if (spawnedItems[i] != null)
            {
                Destroy(spawnedItems[i].gameObject);
            }
        }

        spawnedItems.Clear();
    }
}