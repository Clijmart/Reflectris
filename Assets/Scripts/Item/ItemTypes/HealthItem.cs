using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, IItemType
{
    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField]
    private GameObject pickUpPrefab;

    private void Start()
    {
        IItemType.itemTypeObjects.Add(GetItemType(), this);
    }

    public GameObject ItemPrefab()
    {
        return itemPrefab;
    }

    public GameObject PickUpPrefab()
    {
        return pickUpPrefab;
    }

    public ItemType GetItemType()
    {
        return ItemType.HEALTH;
    }

    public void PickUp()
    {
        GameDataManager.instance.ChangeLives(5);
        GameDataManager.instance.ChangeScore(3);
    }
}
