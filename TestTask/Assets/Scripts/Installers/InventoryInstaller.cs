using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] Inventory _inventory;
    public override void InstallBindings()
    {
        Container.Bind<Inventory>().FromInstance(_inventory).AsSingle();
    }
}