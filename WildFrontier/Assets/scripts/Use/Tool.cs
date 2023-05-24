using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Harvestable harvestable = collision.GetComponent<Harvestable>();
        if(harvestable != null)
        {
            harvestable.Harvest();
        }
    }
}
