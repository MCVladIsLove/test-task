using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventorySlot
{
    private int _amount;
    private ItemData _data;

    public int Amount => _amount;
    public ItemData Item => _data;

    public event Action OnEmpty;
    public int Add(ItemData data, int count)
    {
        if (IsEmpty())
            _data = data;

        int free = data.StackSize - _amount;

        _amount += Mathf.Min(count, free);

        return count - free;
    }

    public int Take(int count)
    {
        if (count > _amount)
        {
            Debug.LogWarning("Trying to get more items than slot contains");
            count = _amount;
        }

        if (count == _amount) Empty();
        else _amount -= count;

        return count;
    }

    public int Empty()
    {
        int toReturn = _amount;
        _amount = 0;
        _data = null;

        OnEmpty?.Invoke();
        return toReturn;
    }

    public bool IsEmpty() => _amount == 0;
    public bool IsFull() => _data != null && _amount == _data.StackSize;
}
