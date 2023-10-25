using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DropListInstaller : MonoInstaller
{
    [SerializeField] DropList _dropList;
    public override void InstallBindings()
    {
        Container.Bind<DropList>().FromInstance(_dropList).AsSingle();
    }
}
