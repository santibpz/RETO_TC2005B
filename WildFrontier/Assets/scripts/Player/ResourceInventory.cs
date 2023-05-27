using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInventory : MonoBehaviour
{
    [SerializeField] public SerializableDictionary<Resource, int> resources;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetResourceCount(Resource type) // function to get resource count
    {
        
        if(resources.TryGetValue(type, out int currentCount))
        {
            return currentCount;
        } else
        {
            return 0;
        }
    }

    public int AddResource(Resource type) // function to add resources
    {
        if (!resources.TryGetValue(type, out int currentCount)) // check if resource already exists in dictionary
        {
            resources.Add(type, 1); // if not, add resource
            return 1;
        } else
        {
            return resources[type] += 1; // if resource exists, add one to the resource count
             
        }
    }

    public void UpdateInventory(Resource type, int newValue)
    {
        if(newValue < 0) // check that new resource value is not negative
        {
            resources[type] = 0;
        } else
        {
            resources[type] = newValue; // update resource count with new value
        }
    }
}
