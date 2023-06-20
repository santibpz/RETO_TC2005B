// script for targeting the harvesting component of the player and assigning the tool to be used 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : MonoBehaviour
{
    [SerializeField] Tool tool;
    [SerializeField] Harvesting harvestingTarget;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeTool()
    {
        if(harvestingTarget!=null)
        {
            harvestingTarget.tool = tool;
        } else
        {
            Debug.LogWarning("target harvesting component is no longer referenced");
        }
    }
}
