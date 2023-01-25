using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IItemType
{
    public static Dictionary<ItemType, IItemType> itemTypeObjects = new();

    /// <summary>
    /// Get the Item Prefab of the item.
    /// </summary>
    /// <returns>A GameObject of the Item Prefab.</returns>
    public abstract GameObject ItemPrefab();

    /// <summary>
    /// Get the PickUp Prefab of the item.
    /// </summary>
    /// <returns>A GameObject of the PickUp Prefab.</returns>
    public abstract GameObject PickUpPrefab();

    /// <summary>
    /// Get the Item Type of the item.
    /// </summary>
    /// <returns>The matching ItemType</returns>
    public abstract ItemType GetItemType();

    /// <summary>
    /// The actions to run when the item has been picked up.
    /// </summary>
    public abstract void PickUp();

    /// <summary>
    /// Get a random Item Type object.
    /// </summary>
    /// <returns>An Item Type object.</returns>
    public static IItemType RandomItemType()
    {
        List<IItemType> itemTypes = Enumerable.ToList(itemTypeObjects.Values);
        return itemTypes[Random.Range(0, itemTypes.Count)];
    }

    /// <summary>
    /// Get the Item Type object matching an Item Type.
    /// </summary>
    /// <param name="itemType">The Item Type to find the object with.</param>
    /// <returns>An Item Type object.</returns>
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
