using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private EnemySpawner _spawner;
    public override void InstallBindings()
    {
        Container.Bind<EnemySpawner>().FromInstance(_spawner).AsSingle();
    }
}
