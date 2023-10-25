using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform _slotsContainer;
    [SerializeField] private InventorySlotUI _slotPrefab;

    public void Show(Inventory inventoryData, bool canDelete = false)
    {
        for (int i = 0; i < inventoryData.Capacity; i++)
        {
            if (inventoryData.GetSlot(i).IsEmpty())
                return;

            InventorySlotUI slot = Instantiate<InventorySlotUI>(_slotPrefab, _slotsContainer);
            slot.Image.sprite = inventoryData.GetSlot(i).Item.Picrture;
            slot.Name.text = inventoryData.GetSlot(i).Item.Name;
            slot.Amount.text = inventoryData.GetSlot(i).Amount.ToString();

            if (inventoryData.GetSlot(i).Amount == 1)
                slot.Amount.enabled = false;
            int j = i;
            if (canDelete)
                slot.OnClick += () =>
                {
                    inventoryData.RemoveSlot(j);
                    Hide();
                    Show(inventoryData, canDelete);
                };
        }
    }

    public void Hide()
    {
        for (int i = 0; i < _slotsContainer.childCount; i++)
            Destroy(_slotsContainer.GetChild(i).gameObject);
    }
}
