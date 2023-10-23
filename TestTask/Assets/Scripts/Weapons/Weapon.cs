using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Weapon : MonoBehaviour, IWeaponEquip
{
    [SerializeField] protected float _cooldown;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _range;

    protected IChooseTarget _targetFinder;

    public float Cooldown => _cooldown;
    public int Damage => _damage;
    public float Range => _range;

    private void Awake()
    {
        _targetFinder = new ClosestTargetFinder();
    }

    public virtual void Equip(WeaponController controller) 
    {
      //Поиск врагов
      //controller.OnAttackBtnClicked += () => Attack();
    }
    public virtual void Unequip(WeaponController controller) 
    {
    }

    public event Action OnAttack;
    public virtual void Attack(Vector2 direction)
    {
        OnAttack?.Invoke();
    }
}
