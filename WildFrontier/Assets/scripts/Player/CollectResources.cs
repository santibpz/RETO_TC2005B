using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectResources : MonoBehaviour
{
    [SerializeField] ResourceInventory inventory;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        ResourcePickup newResource = collision.gameObject.GetComponent<ResourcePickup>();

        if(newResource)
        {
            Destroy(newResource.gameObject);
            inventory.AddResource(newResource.resourceType);

        } 
        
    }
}
