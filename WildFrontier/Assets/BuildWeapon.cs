// script for defining the logic of building a weapon from the collectable resources
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWeapon : MonoBehaviour
{
    ResourceInventory resourceInventory;
    WeaponInventory weaponInventory;
    // Start is called before the first frame update
    void Start()
    {
        resourceInventory = GetComponent<ResourceInventory>();
        weaponInventory = GetComponent<WeaponInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
