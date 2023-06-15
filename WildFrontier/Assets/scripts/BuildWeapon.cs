// script for defining the logic of building a weapon from the collectable resources
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWeapon : MonoBehaviour
{
    public Weapon weapon
    {
        get
        {
            return _weapon;
        }
        set
        {
            if (_weapon != value)
            {
                _weapon = value;
                // update the sprite
                //UpdateSprite();
            }
        }
    }

    public Weapon _weapon;
    public bool selectionChanged = false;

    [SerializeField] ResourceInventory resourceInventory;
    [SerializeField] WeaponInventory weaponInventory;

    int woodRequirement;
    int rockRequirement;

    [SerializeField] Resource wood;
    [SerializeField] Resource rock;

    [SerializeField] Message message;
    // Start is called before the first frame update
    void Start()
    {
        if(_weapon != null)
        {
            woodRequirement = _weapon.woodRequirement;
            rockRequirement = _weapon.rockRequirement;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(_weapon!= null && selectionChanged == true)
        {
            selectionChanged = false;
            woodRequirement = _weapon.woodRequirement;
            rockRequirement = _weapon.rockRequirement;
        }
    }

    public void Build() 
    {

        if(_weapon == null)
        {
            Debug.Log("No weapon selected");
            message.Send("No weapon selected");
        }
        else
        {
            //Debug.Log("keys are" + resourceInventory.resources.Keys);
            int currentWoodAmount = resourceInventory.GetResourceCount(wood);
            int currentRockAmount = resourceInventory.GetResourceCount(rock);

            CheckIfCanBuild(currentWoodAmount, currentRockAmount);
        }
        
        

    }

    private void CheckIfCanBuild(int currentWoodAmount, int currentRockAmount)
    {

        if (currentWoodAmount >= woodRequirement && currentRockAmount >= rockRequirement)
        {
            if(weaponInventory.weapons.ContainsKey(_weapon))
            {
                Debug.Log("weapon already exists in inventory");
                message.Send("Weapon already exists in inventory");
                return;
            } else
            {
                // allow player to build weapon
                weaponInventory.AddWeaponToInventory(_weapon);
                Debug.Log("Weapon successfully created");
                message.Send("Weapon successfully created");

                // update resource inventory
                resourceInventory.UpdateInventory(wood, currentWoodAmount - woodRequirement);
                resourceInventory.UpdateInventory(rock, currentRockAmount - rockRequirement);

            }
            

        } else
        {
            // player does not have enough resources to build a weapon
            Debug.Log("Player does not have enough resources to build weapon"); 
            message.Send("You do not have enough resources to build weapon");

        }
    }

}
