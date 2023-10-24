using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Zenject;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon _equippedWeapon;

    [Inject] private AttackButton _attackButton;    

    public Weapon EquippedWeapon => _equippedWeapon;

    public event Action OnAttackBtnClicked;

    private void Start()
    {
        _attackButton.Btn.onClick.AddListener(AttackButtonClicked);
        _equippedWeapon?.Equip(this);
    }
    public void EquipWeapon(Weapon weapon)
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
