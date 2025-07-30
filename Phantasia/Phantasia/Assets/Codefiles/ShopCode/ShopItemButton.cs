using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShopItemButton : MonoBehaviour, ISelectHandler
{
	[Header("Components")]
	[SerializeField] private Image itemSprite;
	[SerializeField] private Image soldOutOverlay;
	public Button button { get; private set; }
	private UnityAction onSelectAction;
	private ShopObject designatedItem = null;

	private void OnEnable()
	{
		EventsManager.instance.coinEvents.onItemStateChange += ItemStateChanged;
	}

	private void OnDisable()
	{
		EventsManager.instance.coinEvents.onItemStateChange -= ItemStateChanged;
	}

	private void ItemStateChanged(ShopObject item)
	{
		if (designatedItem == item)
		{
			soldOutOverlay.enabled = checkState(designatedItem);
		}
	}

	//since this may be diabled when we instanciate it, we would need to manually instantiate everything
	public void Initialize(ShopObject item, UnityAction selectAction)
	{
		designatedItem = item;
		Refresh();
		SetSelectAction(selectAction);
	}

	public void SetSelectAction(UnityAction selectAction)
	{
		this.onSelectAction = selectAction;
	}

	public void OnSelect(BaseEventData eventData)
    {
		onSelectAction();
	}

	public void Refresh()
	{
		if (designatedItem != null)
		{
			soldOutOverlay.enabled = checkState(designatedItem);
			itemSprite.sprite = designatedItem.getvisual();
			this.button = this.GetComponent<Button>();
		}
	}

	private bool checkState(ShopObject item)
    {
		if (item.state == ItemState.NOT_BOUGHT)
		{
			return false;
		}
        else
        {
			return true;
        }
    }
}
