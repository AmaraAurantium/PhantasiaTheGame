using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopScrollingList : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [Header("ShopItem Button Prefab")]
    [SerializeField] private GameObject shopItemButtonPrefab;

    private Dictionary<string, ShopItemButton> idToButtonMap = new Dictionary<string, ShopItemButton>();

    public void CleanTaskList()
    {
        foreach (var itemButtonInfo in idToButtonMap)
        {
            Destroy(itemButtonInfo.Value.gameObject);
        }

        idToButtonMap = new Dictionary<string, ShopItemButton>();
    }
    public ShopItemButton CreateButtonIfNotExists(ShopObject item, UnityAction selectAction)
    {
        ShopItemButton shopItemButton = null;
        //only create the button if we havent seen this id before
        if (!idToButtonMap.ContainsKey(item.name))
        {
            shopItemButton = InstantiateTaskButton(item, selectAction);
        }
        else
        {
            shopItemButton = idToButtonMap[item.name];
            shopItemButton.Refresh();
            shopItemButton.SetSelectAction(selectAction);
        }
        return shopItemButton;
    }

    private ShopItemButton InstantiateTaskButton(ShopObject item, UnityAction selectAction)
    {
        //create the button
        ShopItemButton shopItemButton = Instantiate(
            shopItemButtonPrefab,
            contentParent.transform).GetComponent<ShopItemButton>();
        //game object name in scene
        shopItemButton.gameObject.name = item.name + "_button";
        //initialize and set up function for when the button is selected
        shopItemButton.Initialize(item, selectAction);
        idToButtonMap[item.name] = shopItemButton;
        return shopItemButton;
    }
}
