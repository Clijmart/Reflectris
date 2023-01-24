using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    [SerializeField]
    private int itemCount = 3;

    public List<Item> spawnedItems = new();

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (spawnedItems.Count == 0)
        {
            SpawnItems();
        }
    }

    private void Start()
    {
        SpawnItems();
    }

    public void RespawnAllItems()
    {
        DespawnAllItems();
        SpawnItems();
    }

    public void Spawn(IItemType itemType, Vector3 spawnPosition)
    {
        GameObject prefab = itemType.ItemPrefab();

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnItems()
    {
        if (!GameManager.instance.IsRunning()) return;

        List<Vector2Int> gridCells = GridController.instance.RandomGridCells(cellAmount: itemCount);
        foreach (Vector2Int gridCell in gridCells)
        {
            Vector3 pos = GridController.instance.CellToPosition(gridCell);
            Spawn(IItemType.RandomItemType(), pos);
        }
    }

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
