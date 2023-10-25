using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CleanInventoryButton : MonoBehaviour
{
    [Inject] Inventory _inventory;
    [Inject] PauseOnOpenInventory _pauser;

    private InventoryUI _inventoryUI;
    private Button _button;

    public Button Button => _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start() // needs special logic to delete items
    {
        _inventoryUI = _inventory.GetComponentInChildren<InventoryUI>(true);
        _button.onClick.AddListener(ShowInventory);
        _button.onClick.AddListener(_pauser.Pause);
    }

    private void ShowInventory()
    {
        _inventoryUI.gameObject.SetActive(true);
        _inventoryUI.Show(_inventory, true);
    }
}
