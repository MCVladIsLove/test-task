using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Zenject;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private IWeaponEquip _equippedWeapon;

    [Inject] AttackButton _attackButton;    
    public IWeaponEquip EquippedWeapon => _equippedWeapon;

    public event Action OnAttackBtnClicked;

    private void Awake()
    {
        _attackButton.Btn.onClick.AddListener(AttackButtonClicked);
    }

    public void EquipWeapon(IWeaponEquip weapon)
    {
        _equippedWeapon.Unequip(this);
        _equippedWeapon = weapon;
        weapon.Equip(this);
    }

    public void AttackButtonClicked()
    {
        OnAttackBtnClicked?.Invoke();
    }

}
