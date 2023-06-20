using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttackWeapon : MonoBehaviour
{
    [SerializeField] public Weapon weapon;
    [SerializeField] EquipWeapon equip;
    [SerializeField] Message message;

    public void SetWeapon()
    {
        if(weapon !=null)
        {
            equip.weapon = weapon;
            message.Send($"{weapon.name} selected");
        }
       
    }
}
