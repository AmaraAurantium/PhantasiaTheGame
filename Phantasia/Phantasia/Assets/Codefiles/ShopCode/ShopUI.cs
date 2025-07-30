using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
	[Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private ShopScrollingList ShopScrollingList;
    [SerializeField] private TextMeshProUGUI coinCount;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemCost;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private Image itemVisual;

    private ShopObject currentSelectedItem = null;

    private Button firstSelectedButton;

    void Start()
    {
        CoinRefresh();
        refreshScrollingList();
    }

    private void OnEnable()
    {
        if (firstSelectedButton)
        {
            firstSelectedButton.Select();
        }
        EventsManager.instance.coinEvents.onCoinAmountChange += CoinAmountChange;
        EventsManager.instance.coinEvents.onItemStateChange += ItemStateChange;
        CoinRefresh();
        refreshScrollingList();
    }

    private void OnDisable()
    {
        EventsManager.instance.coinEvents.onCoinAmountChange -= CoinAmountChange;
        EventsManager.instance.coinEvents.onItemStateChange -= ItemStateChange;
    }

    private void ItemStateChange(ShopObject item)
    {
        refreshScrollingList();
    }

    private void refreshScrollingList()
    {
        ShopScrollingList.CleanTaskList();
        foreach (var itemInfo in ShopManager.instance.itemList)
        {
            ShopItemButton shopItemButton = ShopScrollingList.CreateButtonIfNotExists(itemInfo, () =>
            {
                setItemLogInfo(itemInfo);
            });
            // initialize the first selected button if not already so that it's always the top button
            if (firstSelectedButton == null)
            {
                firstSelectedButton = shopItemButton.button;
            }
        }

        if (firstSelectedButton != null)
        {
            firstSelectedButton.Select();
        }
    }

    private void CoinAmountChange(int amount)
    {
        coinCount.text = UserManager.instance.getCoinCount() + "";
    }

    public void CoinRefresh()
    {
        coinCount.text = UserManager.instance.getCoinCount() + "";

    }

    private void setItemLogInfo(ShopObject item)
    {
        //set the contents of the task into
        currentSelectedItem = item;
        itemName.text = item.name;
        itemDescription.text = item.getDescription();
        itemCost.text = item.getCost() + "";
        itemVisual.sprite = item.getvisual();
        promptText.text = determinePromptText(item);
    }

    private string determinePromptText(ShopObject item)
    {
        if (item.state == ItemState.NOT_BOUGHT)
        {
            return "Purchase";
        }
        else if (item.state == ItemState.BOUGHT)
        {
            return "Gift";
        }
        else
        {
            return "Stow Away";
        }
    }
}
