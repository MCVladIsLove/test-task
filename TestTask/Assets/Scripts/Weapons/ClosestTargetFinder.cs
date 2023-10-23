using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestTargetFinder : IChooseTarget
{
    public Transform GetTarget() 
    {
        return new GameObject().transform;
    }
}
