using UnityEngine;

public class LifeItem : MonoBehaviour, IItemType
{
    [Header("Item Prefabs")]
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject pickUpPrefab;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        IItemType.itemTypeObjects.Add(GetItemType(), this);
    }

    /// <summary>
    /// Get the Item Prefab of the item.
    /// </summary>
    /// <returns>A GameObject of the Item Prefab.</returns>
    public GameObject ItemPrefab()
    {
        return itemPrefab;
    }

    /// <summary>
    /// Get the PickUp Prefab of the item.
    /// </summary>
    /// <returns>A GameObject of the PickUp Prefab.</returns>
    public GameObject PickUpPrefab()
    {
        return pickUpPrefab;
    }

    /// <summary>
    /// Get the Item Type of the item.
    /// </summary>
    /// <returns>The matching ItemType</returns>
    public ItemType GetItemType()
    {
        return ItemType.LIFE;
    }

    /// <summary>
    /// The actions to run when the item has been picked up.
    /// </summary>
    public void PickUp()
    {
        GameDataManager.instance.ChangeLives(amount: 1);
        GameDataManager.instance.ChangeScore(amount: 3);
    }
}
