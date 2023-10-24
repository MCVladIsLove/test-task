using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestTargetFinder : IChooseTarget
{
    private EnemiesTracker _tracker;

    public ClosestTargetFinder(EnemiesTracker tracker)
    {
        _tracker = tracker;
    }

    public Transform GetTarget() 
    {
        if (_tracker.TrackedEnemies.Count == 0)
            return null;

        Enemy closest = _tracker.TrackedEnemies[0];
        float minDistance = Vector2.Distance(_tracker.transform.position, closest.transform.position);
        float distance;
        
        foreach (var enemy in _tracker.TrackedEnemies)
            if ((distance = Vector2.Distance(_tracker.transform.position, enemy.transform.position)) < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }

        return closest.transform;
    }
}
