using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropList : MonoBehaviour
{
    [field: SerializeField] public List<DropInfo> Drops { get; private set; }
    
    private int _weightsSum;
    public int SumOfWeight => _weightsSum;
    
    private void Awake()
    {
        _weightsSum = 0;
        Drops.ForEach(x => _weightsSum += x.Weight);
    }
}
