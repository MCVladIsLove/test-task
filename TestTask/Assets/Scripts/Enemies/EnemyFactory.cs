using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyFactory
{
    DiContainer _DIcontrainer;

    private Enemy _enemyPrefab;
    private Transform _parent;

    public EnemyFactory(Enemy enemyPrefab, Transform parent, DiContainer diContainer)
    {
        _DIcontrainer = diContainer;
        _enemyPrefab = enemyPrefab;
        _parent = parent;
    }

    public Enemy CreateEnemy()
    {
        return _DIcontrainer.InstantiatePrefab(_enemyPrefab, _parent).GetComponent<Enemy>();
    }
}
