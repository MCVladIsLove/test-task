using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryPauseInstaller : MonoInstaller
{
    [SerializeField] PauseOnOpenInventory _pauser;
    public override void InstallBindings()
    {
        Container.Bind<PauseOnOpenInventory>().FromInstance(_pauser).AsSingle();
    }
}
