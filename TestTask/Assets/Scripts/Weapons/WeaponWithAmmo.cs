using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponWithAmmo : Weapon
{
    [SerializeField] private ItemData _ammo;
    [SerializeField] private int _spendPerShot;
    [SerializeField] protected float _projectileSpeed;
    [SerializeField] Player _player;

    [Inject] Inventory _inventory;
    [Inject] ProjectilePool _pool;

    protected Projectile _projectile;

    public float ProjectileSpeed => _projectileSpeed;

    public override void Attack()
    {
        if (_timeAfterShot < _cooldown)
            return;
        
        Transform target;
        if ((target = _targetFinder.GetTarget()) == null)
            return;

        if (!SpendAmmo())
            return;

        _projectile = _pool.Get();

        _projectile.Init(this, target.position, _player, 2);
        _timeAfterShot = 0;
        base.Attack();
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
