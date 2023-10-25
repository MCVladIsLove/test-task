using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryHolder : MonoBehaviour
{
    [Inject] private Inventory _inventory;

    public Inventory Inventory => _inventory;
}
