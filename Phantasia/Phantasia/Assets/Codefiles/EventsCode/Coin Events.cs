using System;

public class CoinEvents
{
    public event Action<int> onCoinAdded;
    public void CoinAdded(int amount)
    {
        if (onCoinAdded != null)
        {
            onCoinAdded(amount);
        }
    }

    public event Action<int> onCoinSpent;
    public void CoinSpent(int amount)
    {
        if (onCoinSpent != null)
        {
            onCoinSpent(amount);
        }
    }

    public event Action<int> onCoinAmountChange;
    public void CoinAmountChange(int amount)
    {
        if (onCoinAmountChange != null)
        {
            onCoinAmountChange(amount);
        }
    }

    public event Action<ShopObject> onItemPurchase;
    public void ItemPurchase(ShopObject item)
    {
        if (onItemPurchase != null)
        {
            onItemPurchase(item);
        }
    }

    public event Action<ShopObject> onItemGifted;
    public void ItemGifted(ShopObject item)
    {
        if (onItemGifted != null)
        {
            onItemGifted(item);
        }
    }

    public event Action<ShopObject> onItemUngifted;
    public void ItemUngifted(ShopObject item)
    {
        if (onItemUngifted != null)
        {
            onItemUngifted(item);
        }
    }
}
