// script for defining the weapon inventory of the player as a dictionary
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PlayerWeapon
{
    public int player_id;
    public int weapon_id;
    public int weapon_damage;
}

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] public SerializableDictionary<Weapon, bool> weapons;
    [SerializeField] GameObject[] weaponSlots;
    [SerializeField] InsertWeapon insertWeapon;
    int avaliableWeaponSlot = 0;

    public void AddWeaponToInventory(Weapon weapon)
    {
        weapons[weapon] = true;

        if(weaponSlots!=null)
        {
            //weaponSlots[0].SetActive(true);
            SetWeaponToInventorySlot(weapon);
            PlayerWeapon playerWeapon = new PlayerWeapon();
            playerWeapon.player_id = PlayerPrefs.GetInt("player_id");
            playerWeapon.weapon_id = weapon.weapon_id;
            playerWeapon.weapon_damage = weapon.damage;
            string playerWeaponData = JsonUtility.ToJson(playerWeapon);

            insertWeapon.QueryAddWeapon(playerWeaponData);
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
