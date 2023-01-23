using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    public List<Item> spawnedItems = new();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Spawn(ItemType.COIN, new Vector3(-3f, GridController.instance.GetGridPosition().y, -3f));
        Spawn(ItemType.HEALTH, new Vector3(3f, GridController.instance.GetGridPosition().y, 3f));
    }

    public void Spawn(ItemType itemType, Vector3 spawnPosition)
    {
        GameObject prefab = IItemType.itemTypeObjects[itemType].ItemPrefab();

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
