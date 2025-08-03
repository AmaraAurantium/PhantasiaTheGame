using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int coinCount;
    public GameState gameState;
    public List<TaskObject> taskList;
    public List<ShopObject> shopList;

    public SaveData()
    {
        this.coinCount = 0;
        this.gameState = GameState.INTRO;
        this.taskList = null;
        this.shopList = null;
    }
}
