using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] public List<ShopObject> itemList = new List<ShopObject>();
	//list of materials
	[SerializeField] private Material Room1;
	[SerializeField] private Material Room1Dark;
	[SerializeField] private Material Room2;
	[SerializeField] private Material Room2Dark;
	[SerializeField] private Material Room3;
	[SerializeField] private Material Room3Dark;
	[SerializeField] private Material Room4;
	[SerializeField] private Material Room4Dark;
	[SerializeField] private Material Room5;
	[SerializeField] private Material Room5Dark;
	[SerializeField] private Material Floor;
	[SerializeField] private Material FloorDark;
	[SerializeField] private Material Wall;
	[SerializeField] private Material WallDark;

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
				if (renderer.material == Room1Dark)
				{
					renderer.material = Room1;
				}
				else if (renderer.material == Room2Dark)
				{
					renderer.material = Room2;
				}
				else if (renderer.material == Room3Dark)
				{
					renderer.material = Room3;
				}
				else if (renderer.material == Room4Dark)
				{
					renderer.material = Room4;
				}
				else if (renderer.material == Room5Dark)
				{
					renderer.material = Room5;
				}
				else if (renderer.material == FloorDark)
				{
					renderer.material = Floor;
				}
				else
				{
					renderer.material = Wall;
				}
			}
		}
		else
		{
			foreach (GameObject furnature in item.getItems())
			{
				Renderer renderer = furnature.GetComponent<Renderer>();
				if (renderer.material == Room1)
				{
					renderer.material = Room1Dark;
				}
				else if (renderer.material == Room2)
				{
					renderer.material = Room2Dark;
				}
				else if (renderer.material == Room3)
				{
					renderer.material = Room3Dark;
				}
				else if (renderer.material == Room4)
				{
					renderer.material = Room4Dark;
				}
				else if (renderer.material == Room5)
				{
					renderer.material = Room5Dark;
				}
				else if (renderer.material == Floor)
				{
					renderer.material = FloorDark;
				}
				else
				{
					renderer.material = WallDark;
				}
			}
		}
    }
}
