using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;

    private void Start()
    {
        ItemManager.instance.spawnedItems.Add(this);
    }

    public void PickUp()
    {
        IItemType item = IItemType.GetFromType(itemType);
        item.PickUp();

        GameObject pickUpPrefab = item.PickUpPrefab();
        Instantiate(pickUpPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));

        Remove();
    }

    public void Remove()
    {
        ItemManager.instance.spawnedItems.Remove(this);
        Destroy(gameObject);
    }
}
