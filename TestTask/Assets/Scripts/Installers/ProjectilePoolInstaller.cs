using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectilePoolInstaller : MonoInstaller
{
    [SerializeField] private GameObject _projectilePool;
    public override void InstallBindings()
    {
        Container.Bind<ProjectilePool>().FromComponentOn(_projectilePool).AsSingle();
    }
}
