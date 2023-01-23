using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, IItemType
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
        return ItemType.COIN;
    }

    public void PickUp()
    {
        GameDataManager.instance.ChangeScore(5);
    }
}
