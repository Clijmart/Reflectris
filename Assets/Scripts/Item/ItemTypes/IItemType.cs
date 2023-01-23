using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IItemType
{
    public static Dictionary<ItemType, IItemType> itemTypeObjects = new();

    public abstract GameObject ItemPrefab();
    public abstract GameObject PickUpPrefab();

    public abstract void PickUp();

    public abstract ItemType GetItemType();

    public static IItemType RandomItemType()
    {
        List<IItemType> itemTypes = Enumerable.ToList(itemTypeObjects.Values);
        return itemTypes[Random.Range(0, itemTypes.Count)];
    }

    public static IItemType GetFromType(ItemType itemType)
    {
        return itemTypeObjects[itemType];
    }
}

public enum ItemType
{
    COIN,
    HEALTH,
}
