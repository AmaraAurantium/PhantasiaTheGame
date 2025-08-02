using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] public List<ShopObject> itemList = new List<ShopObject>();

	public static ShopManager instance = null;

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
			foreach (GameObject furnature in item.getItems())
			{
				Renderer renderer = furnature.GetComponent<Renderer>();
				renderer.material = item.getColorMat();
			}
		}
		else
		{
			foreach (GameObject furnature in item.getItems())
			{
				Renderer renderer = furnature.GetComponent<Renderer>();
				renderer.material = item.getDarkMat();
			}
		}
    }
}
