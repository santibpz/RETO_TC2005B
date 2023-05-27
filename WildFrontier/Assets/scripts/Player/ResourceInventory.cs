using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInventory : MonoBehaviour
{
    [SerializeField] SerializableDictionary<Resource, int> resources;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetResourceCount(Resource type)
    {
        if(resources.TryGetValue(type, out int currentCount))
        {
            return currentCount;
        } else
        {
            return 0;
        }
    }

    public int AddResource(Resource type)
    {
        if (!resources.TryGetValue(type, out int currentCount))
        {
            resources.Add(type, 1);
            return 1;
        } else
        {
            return resources[type] += 1;
             
        }
    }
}
