using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private int _stackSize;
    [SerializeField] private string _name;
    [SerializeField] private readonly Sprite _picture;

    public string Name => _name;
    public int StackSize => _stackSize;
    public Sprite Picrture => _picture;
}
