using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private int _stackSize;
    [SerializeField] private string _name;
    //img
    public string Name { get { return _name; } }
    public int StackSize { get { return _stackSize; } }
}
