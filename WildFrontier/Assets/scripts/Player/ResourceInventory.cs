using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceInventory : MonoBehaviour
{
    [SerializeField] public SerializableDictionary<Resource, int> resources;
    private GameObject[] resourceSlots;
    private int currentSlot = 0;
    private TMP_Text currentText;
    // Start is called before the first frame update
    void Start()
    {
        resourceSlots = GameObject.FindGameObjectsWithTag("ResourceSlot");
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

    public void AddResource(Resource type) // function to add resources
    {
        if (!resources.TryGetValue(type, out int currentCount)) // check if resource already exists in dictionary
        {
            resourceSlots[currentSlot].GetComponent<Image>().sprite = type.icon;
            currentSlot++;
            resources.Add(type, 1); // if not, add resource
            
           
            
        } else
        {

            resources[type] += 1; // if resource exists, add one to the resource count
            
        }

        UpdateInventorySlots(type, resources[type]); // updating the resources slots
    }

    public void UpdateInventory(Resource type, int newValue)
    {
        if(newValue < 0) // check that new resource value is not negative
        {
            resources[type] = 0;
            UpdateInventorySlots(type, 0);
        } else
        {
            resources[type] = newValue; // update resource count with new value
            UpdateInventorySlots(type, newValue);
        }
    }

    private void UpdateInventorySlots(Resource type, int value)
    {
        for (int i = 0; i < resourceSlots.Length; i++)
        {
            if(resourceSlots[i].GetComponent<Image>().sprite.name == type.icon.name)
            {
                // update current amount
                resourceSlots[i].GetComponentInChildren<TMP_Text>().text = value.ToString();
            }
        }
    }
}
