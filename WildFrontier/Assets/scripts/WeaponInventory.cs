// script for defining the weapon inventory of the player as a dictionary
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] public SerializableDictionary<Weapon, bool> weapons;
    [SerializeField] GameObject[] weaponSlots;
    int avaliableWeaponSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {

    }

    public void AddWeaponToInventory(Weapon weapon)
    {
        weapons[weapon] = true;

        if(weaponSlots!=null)
        {
            //weaponSlots[0].SetActive(true);
            SetWeaponToInventorySlot(weapon);
        }
        else
        {
            Debug.Log("if not entered");
        }
    }

    private void SetWeaponToInventorySlot(Weapon weapon)
    {
        weaponSlots[avaliableWeaponSlot].GetComponent<Image>().sprite = weapon.icon;
        weaponSlots[avaliableWeaponSlot].GetComponent<SetAttackWeapon>().weapon = weapon;
        avaliableWeaponSlot++;
        
    }
}
