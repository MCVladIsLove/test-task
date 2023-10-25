using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CloseInventoryButton : MonoBehaviour
{
    [Inject] Inventory _inventory;
    [Inject] private PauseOnOpenInventory _pauser;

    private Button _closeButton;
    private InventoryUI _inventoryUI;

    private void Awake()
    {
        _closeButton = GetComponent<Button>();
    }

    private void Start()
    {
        _inventoryUI = _inventory.GetComponentInChildren<InventoryUI>();
        _closeButton.onClick.AddListener(CloseInventory);
        _closeButton.onClick.AddListener(_pauser.UnPause);
    }

    private void CloseInventory()
    {
        _inventoryUI.gameObject.SetActive(false);
        _inventoryUI.Hide();
    }
}
