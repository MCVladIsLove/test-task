using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _zombiePrefab;
    [SerializeField] Enemy _fleshPrefab;
    [SerializeField] Transform _container;

    RectTransform _spawnArea;
    EnemyFactory _zombieFactory;
    EnemyFactory _fleshFactory;

    [Inject]
    private void Construct(DiContainer diContainer)
    {
        _zombieFactory = new EnemyFactory(_zombiePrefab, _container, diContainer);
        _fleshFactory = new EnemyFactory(_fleshPrefab, _container, diContainer);
    }


    private void Awake()
    {
        _spawnArea = GetComponent<RectTransform>();
    }

    public void Spawn()
    {
        int x = (int)Random.Range(_spawnArea.rect.xMin, _spawnArea.rect.xMax);
        int y = (int)Random.Range(_spawnArea.rect.yMin, _spawnArea.rect.yMax);

        Enemy created;
        if (Random.value > 0.7)
            created = _zombieFactory.CreateEnemy();
        else
            created = _fleshFactory.CreateEnemy();

        created.transform.position = new Vector2(x, y);
    }
}
