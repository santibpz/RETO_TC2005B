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

public class CheckReceivedData : MonoBehaviour
{
    [SerializeField] ResourceInventory resourceInventory;
    [SerializeField] Resource rockResource;
    [SerializeField] Resource woodResource;
    PlayerItems items;
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

}
