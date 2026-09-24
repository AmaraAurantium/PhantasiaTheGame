using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ShopObject
{
    public string name;
    public ItemState GetState() { return state; }
    public ItemState state;// { get; private set; }
    private bool isDeco;
    private int cost;
    private string description;
    private int[] itemsID;
    private int visualID;
    private int colorMatID;
    private int darkMatID;

    //constructor
    public ShopObject(string itemName, bool itemIsDeco , int itemCost, string itemdescription, int[] itemSubitems, int itemVisual, int def, int change)
    {
        name = itemName;
        state = ItemState.NOT_BOUGHT;
        isDeco = itemIsDeco;
        cost = itemCost;
        description = itemdescription;
        itemsID = itemSubitems;
        visualID = itemVisual;
        colorMatID = change;
        darkMatID = def;
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

    public int[] getItems()
    {
        return itemsID;
    }

    public int getvisual()
    {
        return visualID;
    }

    public int getColorMat()
    {
        return colorMatID;
    }

    public int getDarkMat()
    {
        return darkMatID;
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