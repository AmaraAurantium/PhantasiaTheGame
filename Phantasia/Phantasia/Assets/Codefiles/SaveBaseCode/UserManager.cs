using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour, IDataPersistance
{
    public int coins;
    private static UserManager _instance = null;

    public static UserManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("UserManager");
                _instance = go.AddComponent<UserManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public void loadData(SaveData data)
    {
        this.coins = data.coinCount;
    }

    public void saveData(ref SaveData data)
    {
        data.coinCount = this.coins;
    }

    private void Start()
    {
        //coins = 0;
        EventsManager.instance.coinEvents.CoinAmountChange(coins);
    }


    private void OnEnable()
    {
        EventsManager.instance.coinEvents.onCoinAdded += coinAdded;
        EventsManager.instance.coinEvents.onCoinSpent += coinSpent;
    }

    private void OnDisable()
    {
        EventsManager.instance.coinEvents.onCoinAdded -= coinAdded;
        EventsManager.instance.coinEvents.onCoinSpent -= coinSpent;
    }

    private void coinAdded(int amount)
    {
        coins += amount;
        EventsManager.instance.coinEvents.CoinAmountChange(coins);
    }

    private void coinSpent(int amount)
    {
        coins -= amount;
        EventsManager.instance.coinEvents.CoinAmountChange(coins);
    }

    public int getCoinCount()
    {
        return coins;
    }
}
