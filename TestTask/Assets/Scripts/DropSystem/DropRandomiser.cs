using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRandomiser
{
    private DropList _dropList;
    private Collectable _dropToReturn;

    public DropRandomiser(DropList list)
    {
        _dropList = list;
    }

    public Collectable GetDrop()
    {
        int rand = Random.Range(1, _dropList.SumOfWeight+1);
        int sum = 0;
        foreach (var drop in _dropList.Drops)
        {
            sum += drop.Weight;
            if (sum >= rand)
            {
                _dropToReturn = GameObject.Instantiate<Collectable>(drop.CollectablePrefab);
                _dropToReturn.Count = Random.Range(1, drop.MaxCountInDrop + 1);

                return _dropToReturn;
            }
        }

        Debug.LogError("Method GetDropPrefab returned null");

        return null;
    }
}
