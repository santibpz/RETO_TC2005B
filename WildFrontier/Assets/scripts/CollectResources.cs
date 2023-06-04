using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerResource
{
    public int player_id;
    public int item_id;
}

public class CollectResources : MonoBehaviour
{
    [SerializeField] ResourceInventory inventory;
    [SerializeField] UpdateResources updateResources;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        ResourcePickup newResource = collision.gameObject.GetComponent<ResourcePickup>();

        if(newResource)
        {
            Destroy(newResource.gameObject);
            inventory.AddResource(newResource.resourceType);

            // make the request to update the player's resources in the database
            PlayerResource playerResource = new PlayerResource();
            playerResource.player_id = PlayerPrefs.GetInt("player_id");
            playerResource.item_id = newResource.resourceType.item_id;

            string updateData = JsonUtility.ToJson(playerResource);

            Debug.Log("*****DATA******:" + updateData);

            updateResources.QueryUpdate(updateData);

        } 
        
    }
}
