using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponWithAmmo : Weapon
{
    [SerializeField] private ItemData _ammo;
    [SerializeField] private int _spendPerShot;
    [SerializeField] protected float _projectileSpeed;

    [Inject] Inventory _inventory;
    public override void Attack(Vector2 direction)
    {
        if (!SpendAmmo())
            return;
        // spawn bullets etc
        base.Attack(direction);
    }

    private bool SpendAmmo()
    {
        return _inventory.TakeItem(_ammo, _spendPerShot, true) == _spendPerShot;
    }

    public override void Unequip(WeaponController controller)
    {
        base.Unequip(controller);
    }
    public override void Equip(WeaponController controller)
    {
        base.Equip(controller);
    }
}
