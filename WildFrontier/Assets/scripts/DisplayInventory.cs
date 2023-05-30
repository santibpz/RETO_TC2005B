// script for displaying the inventory on click
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] WeaponInventory inventory;

    public void DisplayInventoryScreen()
    {
        inventoryPanel.SetActive(true);
    }

}
