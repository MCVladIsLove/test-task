using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DropInfo
{
    [field: SerializeField] public int Weight { get; private set; }
    [field: SerializeField] public int MaxCountInDrop { get; private set; }
    [field: SerializeField] public Collectable CollectablePrefab { get; private set; }
}
