using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _capacity;

    private InventorySlot[] _slots;

    private void Awake()
    {
        _slots = new InventorySlot[_capacity];
        for (int i = 0; i < _capacity; i++) _slots[i] = new InventorySlot();
    }

    public int AddItem(ItemData itemData, int count)
    {
        InventorySlot slot;
        int remained = count;
        while ((slot = GetFreeSlot(itemData)) != null && remained > 0)
            remained = slot.Add(itemData, remained);

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

        return slot.Take(count);
    }


    // tmp test shit
   /* private void Update()
    {
        foreach (var s in _slots)
            print(s.Amount);
    }*/
}
