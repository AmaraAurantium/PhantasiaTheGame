using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    [SerializeField] public int coins = 0;


    private void Start()
    {
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
}
