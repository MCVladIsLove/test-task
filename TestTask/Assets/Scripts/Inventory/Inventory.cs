using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _capacity;

    private InventorySlot[] _slots;

    public int Capacity => _capacity;

    public event Action OnChanged;

    private void Awake()
    {
        OnChanged += Rearrange;
        _slots = new InventorySlot[_capacity];
        for (int i = 0; i < _capacity; i++) _slots[i] = new InventorySlot();
    }

    public int AddItem(ItemData itemData, int count)
    {
        InventorySlot slot;
        int remained = count;
        while ((slot = GetFreeSlot(itemData)) != null && remained > 0)
            remained = slot.Add(itemData, remained);

        OnChanged?.Invoke();

        return remained > 0 ? remained : 0;
    }

    private InventorySlot GetFreeSlot(ItemData itemData)
    {
        foreach (var slot in _slots)
            if (slot.IsEmpty() || slot.Item.Equals(itemData) && !slot.IsFull())
                return slot;

        return null;
    }

    private InventorySlot GetSlot(ItemData itemData)
    {
        foreach (var slot in _slots)
            if (slot.IsEmpty() || slot.Item.Equals(itemData))
                return slot;

        return null;
    }
    public InventorySlot GetSlot(int ind)
    {
        if (ind >= _capacity)
            return null;

        return _slots[ind];
    }
    private InventorySlot GetSlotWith(ItemData itemData)
    {
        foreach (var slot in _slots)
            if (!slot.IsEmpty() && slot.Item.Equals(itemData))
                return slot;

        return null;
    }

    public int TakeItem(ItemData itemData, int count, bool dontTakeIfLess)
    {
        InventorySlot slot = GetSlotWith(itemData);
        if (slot == null)
            return 0;

        if (dontTakeIfLess && slot.Amount < count)
            return 0;

        int taken = slot.Take(count);

        OnChanged?.Invoke();

        return taken;
    }

    public void RemoveSlot(int slotId)
    {
        if (slotId >= _capacity)
        {
            Debug.LogError("Trying to remove item slot with wrong id");
            return;
        }

        _slots[slotId].Empty();

        OnChanged?.Invoke();
    }

    public void Rearrange()
    {
        int i = 0;
        while (i < _capacity)
        {
            InventorySlot slot = _slots[i];
            if (slot.IsEmpty())
            {
                int j = i + 1;
                for (; j < _capacity; j++)
                    if (!_slots[j].IsEmpty())
                    {
                        slot.Add(_slots[j].Item, _slots[j].Empty());
                        break;
                    }
                if (j == _capacity)
                    break; // only nulls further
            }

            if (slot.Amount < slot.Item.StackSize)
            {
                int j = i + 1;
                for (; j < _capacity; j++)
                {
                    if (!_slots[j].IsEmpty() && _slots[j].Item.Equals(slot.Item))
                    {
                        int needToFull = slot.Item.StackSize - slot.Amount;
                        slot.Add(_slots[j].Item, _slots[j].Take(needToFull));
                        if (slot.IsFull())
                            break;
                    }
                }
            }
            i++;
        }
    }
}
