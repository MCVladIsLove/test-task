using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot
{
    private int _amount;
    private InventoryItemData _data;

    public int Amount => _amount;
    public InventoryItemData Item => _data;

    public int Add(InventoryItemData data, int count)
    {
        if (IsEmpty())
            _data = data;

        int free = data.StackSize - _amount;

        _amount += Mathf.Min(count, free);

        return count - free;
    }

    public bool IsEmpty() => _amount == 0;
    public bool IsFull() => _data != null && _amount == _data.StackSize;

}
