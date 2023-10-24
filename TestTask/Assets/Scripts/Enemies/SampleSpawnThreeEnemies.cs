using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSpawnThreeEnemies : MonoBehaviour
{
    void Start()
    {
        EnemySpawner spawner = GetComponent<EnemySpawner>();
        spawner.Spawn();
        spawner.Spawn();
        spawner.Spawn();
    }
}
