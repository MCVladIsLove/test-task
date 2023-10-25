using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private ItemData _data;

    private InventoryHolder _holder;

    public int Count { get => _count; set => _count = value; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<InventoryHolder>(out _holder))
        {
            _count = _holder.Inventory.AddItem(_data, _count);
            if (_count == 0)
                Destroy(gameObject);
        }
    }
}
