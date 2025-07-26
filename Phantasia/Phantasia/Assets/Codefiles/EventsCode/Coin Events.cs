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
}
