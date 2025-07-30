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
    [SerializeField] private string description;
    [SerializeField] private GameObject[] items;
    [SerializeField] private Sprite visual;

    //constructor
    public ShopObject(string itemName, bool itemIsDeco , int itemCost, string itemdescription, GameObject[] itemSubitems, Sprite itemVisual)
    {
        name = itemName;
        state = ItemState.NOT_BOUGHT;
        isDeco = itemIsDeco;
        cost = itemCost;
        description = itemdescription;
        items = itemSubitems;
        visual = itemVisual;
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

    public string getDescription()
    {
        return description;
    }

    public GameObject[] getItems()
    {
        return items;
    }

    public Sprite getvisual()
    {
        return visual;
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