// script for setting the weapon to build on selection any of the weapons available
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWeapon : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] BuildWeapon build;

    public void Set()
    {
        if(weapon!=null)
        {
            build.weapon = weapon;
            build.selectionChanged = true;
        }
    }
}
