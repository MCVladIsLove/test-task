using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    public override void InstallBindings()
    {
        GameObject player = Container.InstantiatePrefab(_playerPrefab);
        Container.Bind<Player>().FromComponentOn(player).AsSingle();
        Container.Bind<EnemiesTracker>()
            .FromComponentOn(player.GetComponentInChildren<EnemiesTracker>().gameObject)
            .AsSingle();
    }
}
