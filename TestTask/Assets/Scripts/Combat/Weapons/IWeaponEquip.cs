using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponEquip
{
    public void Equip(WeaponController controller);
    public void Unequip(WeaponController controller);
}
