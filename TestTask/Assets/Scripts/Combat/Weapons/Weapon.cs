using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public abstract class Weapon : MonoBehaviour, IWeaponEquip
{
    [SerializeField] protected float _cooldown;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _range;
    [SerializeField] protected EnemiesTracker _enemiesTracker;

    protected WeaponController _controller;
    protected IChooseTarget _targetFinder;
    protected float _timeAfterShot;

    public float Cooldown => _cooldown;
    public int Damage => _damage;
    public float Range => _range;

    private void Start()
    {
        _targetFinder = new ClosestTargetFinder(_enemiesTracker);
    }
    public virtual void Equip(WeaponController controller) 
    {
        _controller = controller;
        _enemiesTracker.TrackTrigger.radius = _range;
        controller.OnAttackBtnClicked += Attack;
    }
    public virtual void Unequip(WeaponController controller) 
    {
        _controller = null;
        controller.OnAttackBtnClicked -= Attack;
    }

    public event Action OnAttack;
    public virtual void Attack()
    {
        OnAttack?.Invoke();
    }
    private void Update()
    {
        _timeAfterShot += Time.deltaTime;
    }
}
