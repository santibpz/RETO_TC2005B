using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvestable : MonoBehaviour
{
    [SerializeField] public ToolType toolType;
    // variable to check if the resources spawned has gone above the count
    [SerializeField] int harvestLimit;

    private int amountHarvested = 0;

    [SerializeField]  ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Harvest(int amount)
    {
        // It is not allowed to harvest more resources that specified
        int amountToSpawn = Mathf.Min(amount, harvestLimit - amountHarvested);
        if(amountToSpawn > 0)
        {
            particleSystem.Emit(amountToSpawn);
            amountHarvested += amountToSpawn;
        }
        if(amountHarvested >= harvestLimit)
        {
            // Node is depleted
            Destroy(gameObject);
        }
        
    }
}