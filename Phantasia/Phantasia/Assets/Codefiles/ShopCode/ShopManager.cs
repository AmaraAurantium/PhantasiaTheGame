using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour, IDataPersistance 
{
    [SerializeField] public List<ShopObject> itemList = new List<ShopObject>();

	public static ShopManager instance = null;

	public void loadData(SaveData data)
	{
		if (data.shopList != null)
        {
			this.itemList = data.shopList;
			foreach (ShopObject item in itemList)
            {
				if (item.state == ItemState.GIFTED)
                {
					changeLook(item, true);
				}
                else
                {
					changeLook(item, false);
				}
            }
        }
	}

	public void saveData(ref SaveData data)
	{
		data.shopList = this.itemList;
	}

	private void Awake()
	{
		instance = this;
	}

    private void OnEnable()
    {
		EventsManager.instance.coinEvents.onItemPurchase += ItemPurchase;
		EventsManager.instance.coinEvents.onItemGifted += ItemGifted;
		EventsManager.instance.coinEvents.onItemUngifted += ItemUngifted;
	}

	private void OnDisable()
	{
		EventsManager.instance.coinEvents.onItemPurchase -= ItemPurchase;
		EventsManager.instance.coinEvents.onItemGifted -= ItemGifted;
		EventsManager.instance.coinEvents.onItemUngifted -= ItemUngifted;
	}

	private void ItemPurchase(ShopObject item)
    {
		item.buyItem();
		EventsManager.instance.coinEvents.CoinSpent(item.getCost());
	}

	private void ItemGifted(ShopObject item)
	{
		item.giftItem();
		changeLook(item, true);
	}

	private void ItemUngifted(ShopObject item)
	{
		item.ungiftItem();
		changeLook(item, false);
	}

	private ShopObject GetTaskByID(string id)
	{
		foreach (var item in itemList)
		{
			if (id == item.name)
			{
				return item;
			}
		}
		Debug.LogError("ID not found in taskList: " + id);
		return null;
	}

	private void changeLook(ShopObject item, bool colorlessToColor)
		//colorlessToColor true when converting from dark to color
    {
		if (colorlessToColor)
		{
			bool itemIsDeco = item.getIsDeco();
			foreach (GameObject furnature in item.getItems())
			{
                if (itemIsDeco)
                {
					furnature.SetActive(true);
                }
				Renderer renderer = furnature.GetComponent<Renderer>();
				renderer.material = item.getColorMat();
			}
		}
		else
		{
			bool itemIsDeco = item.getIsDeco();
			foreach (GameObject furnature in item.getItems())
			{
				if (itemIsDeco)
				{
					furnature.SetActive(false);
				}
				Renderer renderer = furnature.GetComponent<Renderer>();
				renderer.material = item.getDarkMat();
			}
		}
    }
}
