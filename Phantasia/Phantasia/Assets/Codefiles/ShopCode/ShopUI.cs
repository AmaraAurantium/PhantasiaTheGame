using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] private TextMeshProUGUI coinCount;
    private void OnEnable()
    {
        EventsManager.instance.coinEvents.onCoinAmountChange += CoinAmountChange;
    }

    private void OnDisable()
    {
        EventsManager.instance.coinEvents.onCoinAmountChange -= CoinAmountChange;
    }

    private void CoinAmountChange(int amount)
    {
        coinCount.text = amount + "";
    }
}
