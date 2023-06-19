using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerItems
{
    public PlayerItem[] playerItems;
}

[System.Serializable]
public class PlayerItem
{
    public string item_name;
    public int quantity;
}

[System.Serializable]
public class PlayerWeapons
{
    public PlayerWpn[] playerWeapons;
}

[System.Serializable]
public class PlayerWpn
{
    public string weapon_name;
    public int weapon_damage;
}


public class CheckReceivedData : MonoBehaviour
{
    [SerializeField] ResourceInventory resourceInventory;
    [SerializeField] WeaponInventory weaponInventory;
    [SerializeField] Resource rockResource;
    [SerializeField] Resource woodResource;
    [SerializeField] Weapon sword;
    [SerializeField] Weapon spear;
    [SerializeField] Weapon knife;
    PlayerItems items;
    PlayerWeapons weapons;
    // Start is called before the first frame update

    public void AddResourceType(string name, int quantity)
    {
        

        if (name == rockResource.item_name)
        {
            Debug.Log("it is a rock");
            resourceInventory.SetInventoryResources(rockResource, quantity);
        } else if(name == woodResource.item_name)
        {
            Debug.Log("it is wood");

            resourceInventory.SetInventoryResources(woodResource, quantity);

        }
    }


    public void AddWeapon(string name)
    {
        switch(name)
        {
            case "Sword":
                weaponInventory.SetWeaponToInventory(sword);
                break;
            case "Spear":
                weaponInventory.SetWeaponToInventory(spear);
                break;
            case "Stone Knife":
                weaponInventory.SetWeaponToInventory(knife);
                break;
            default:
                break;
        }
    }

    public void FetchItems()
    {
        string jsonItems = PlayerPrefs.GetString("items");
        Debug.Log("data from fetch items: " + jsonItems);
        items = JsonUtility.FromJson<PlayerItems>(jsonItems);
        for (int i = 0; i < items.playerItems.Length; i++)
        {
            AddResourceType(items.playerItems[i].item_name, items.playerItems[i].quantity);
        }
    }

    public void FetchWeapons()
    {
        string jsonWeapons = PlayerPrefs.GetString("weapons");
        weapons = JsonUtility.FromJson<PlayerWeapons>(jsonWeapons);
        for (int i = 0; i < weapons.playerWeapons.Length; i++)
        {
            AddWeapon(weapons.playerWeapons[i].weapon_name);
        }
    }

}
