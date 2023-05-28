// script for defining the logic of building a weapon from the collectable resources
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWeapon : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] ResourceInventory resourceInventory;
    [SerializeField] WeaponInventory weaponInventory;

    int woodRequirement;
    int rockRequirement;

    [SerializeField] Resource wood;
    [SerializeField] Resource rock;
    // Start is called before the first frame update
    void Start()
    {
        woodRequirement = weapon.woodRequirement;
        rockRequirement = weapon.rockRequirement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Build() 
    {

        Debug.Log($"{weapon.name} requires {woodRequirement} woods and {rockRequirement}");

        //Debug.Log("keys are" + resourceInventory.resources.Keys);
        int currentWoodAmount = resourceInventory.GetResourceCount(wood);
        int currentRockAmount = resourceInventory.GetResourceCount(rock);
        
        CheckIfCanBuild(currentWoodAmount, currentRockAmount);
        

    }

    private void CheckIfCanBuild(int currentWoodAmount, int currentRockAmount)
    {

        if (currentWoodAmount >= woodRequirement && currentRockAmount >= rockRequirement)
        {
            if(weaponInventory.weapons.ContainsKey(weapon))
            {
                Debug.Log("weapon already exists in inventory");
                return;
            } else
            {
                // allow player to build weapon
                weaponInventory.AddWeaponToInventory(weapon);
                Debug.Log("Weapon successfully created");

                // update resource inventory
                resourceInventory.UpdateInventory(wood, currentWoodAmount - woodRequirement);
                resourceInventory.UpdateInventory(rock, currentRockAmount - rockRequirement);

                // add weapon sprite to a slot in the inventory
            }
            

        } else
        {
            // player does not have enough resources to build a weapon
            Debug.Log("Player does not have enough resources to build weapon");
        }
    }

}
