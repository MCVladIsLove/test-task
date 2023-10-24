using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] AttackButton _attackButton;
    [SerializeField] Joystick _joystick;
    public override void InstallBindings()
    {
        Container.Bind<AttackButton>().FromInstance(_attackButton).AsSingle();
        Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
    }
}