using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Options")]
    [SerializeField] private ItemType itemType;

    /// <summary>
    /// Called just before any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        ItemManager.instance.spawnedItems.Add(this);
    }

    /// <summary>
    /// Pick up the item and spawn pickup effect.
    /// </summary>
    public void PickUp()
    {
        IItemType item = IItemType.GetFromType(itemType);
        item.PickUp();

        GameObject pickUpPrefab = item.PickUpPrefab();
        Instantiate(pickUpPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));

        Remove();
    }

    /// <summary>
    /// Remove the item from the grid.
    /// </summary>
    public void Remove()
    {
        ItemManager.instance.spawnedItems.Remove(this);
        Destroy(gameObject);
    }
}