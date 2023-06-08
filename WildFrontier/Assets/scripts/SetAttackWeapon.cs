using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttackWeapon : MonoBehaviour
{
    [SerializeField] public Weapon weapon;
    [SerializeField] EquipWeapon equip;

    public void SetWeapon()
    {
        equip.weapon = weapon;
    }
}
