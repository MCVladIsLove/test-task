using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] Object _inventoryPrefab;
    public override void InstallBindings()
    {
        Container.Bind<Inventory>().FromComponentInNewPrefab(_inventoryPrefab).AsSingle();
    }
}