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

    public int AddItem(InventoryItemData itemData, int count)
    {
        InventorySlot slot;
        int remained = count;
        while ((slot = GetSlot(itemData)) != null && remained > 0)
            remained = slot.Add(itemData, remained);

        return remained > 0 ? remained : 0;
    }

    private InventorySlot GetSlot(InventoryItemData itemData)
    {
        foreach (var slot in _slots)
        {
            if (slot.IsEmpty() || slot.Item.Equals(itemData) && !slot.IsFull())
                return slot;
        }

        return null;
    }


    // tmp test shit
    private void Update()
    {
        foreach (var s in _slots)
            print(s.Amount);
    }
}
