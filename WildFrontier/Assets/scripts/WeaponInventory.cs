// script for defining the weapon inventory of the player as a dictionary
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] public SerializableDictionary<Weapon, bool> weapons;

    private GameObject[] weaponSlots;

    // Start is called before the first frame update
    void Start()
    {
        weaponSlots = GameObject.FindGameObjectsWithTag("WeaponSlot");
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
            weaponSlots[0].SetActive(true);
            weaponSlots[0].GetComponent<Image>().sprite = weapon.icon;
        }
    }

}
