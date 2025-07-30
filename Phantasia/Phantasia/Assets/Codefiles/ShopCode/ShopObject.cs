using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ShopObject
{
    public string name;
    public ItemState state { get; private set; }
    [SerializeField] private bool isDeco;
    [SerializeField] private int cost;
    [SerializeField] private GameObject[] items;

    //constructor
    public ShopObject(string itemName, bool itemIsDeco , int itemCost)
    {
        name = itemName;
        state = ItemState.NOT_BOUGHT;
        isDeco = itemIsDeco;
        cost = itemCost;
    }

    //get methods
    public bool getIsDeco()
    {
        return isDeco;
    }

    public int getCost()
    {
        return cost;
    }

    public GameObject[] getItems()
    {
        return items;
    }

    //statechange methods
    public void buyItem()
    {
        state = ItemState.BOUGHT;
    }

    public void giftItem()
    {
        state = ItemState.GIFTED;
    }


    public void ungiftItem()
    {
        state = ItemState.BOUGHT;
    }
}