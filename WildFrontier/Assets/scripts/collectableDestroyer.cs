// Destroyer script for block prefabs on collision with the ball
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Rock"))
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Wooden"))
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("RedH"))
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("BlueH"))
        {
            Destroy(other.gameObject);
        }
        
    }
}
