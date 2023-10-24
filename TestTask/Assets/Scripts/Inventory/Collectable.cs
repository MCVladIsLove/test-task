using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Collectable : MonoBehaviour
{
    [SerializeField] int _count;
    [SerializeField] ItemData _data;

    [Inject] Inventory _inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<InventoryHolder>() != null)
        {
            _count = _inventory.AddItem(_data, _count);
            if (_count == 0)
                Destroy(gameObject);
        }

    }


}
