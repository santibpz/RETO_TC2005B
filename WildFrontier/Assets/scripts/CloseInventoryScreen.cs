// script for closing the inventory screen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventoryScreen : MonoBehaviour
{
    private GameObject inventoryPanel;
    private void Start()
    {
        inventoryPanel = GameObject.FindGameObjectWithTag("Inventory");
    }

    public void CloseScreen()
    {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
