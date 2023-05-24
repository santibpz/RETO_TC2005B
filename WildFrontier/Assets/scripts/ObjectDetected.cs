using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetected : MonoBehaviour
{    
    Select select;
    public string DetectedObject;
    // Start is called before the first frame update
    void Start()
    {
        select=GetComponent<Select>();
       DetectedObject="";
    }

    // Update is called once per frame.
    void Update()
    {
         if (select.found == 1){
            DetectedObject = "Sword";
        }
        else if (select.found == 2){
            DetectedObject = "Lance";
        }
        else if (select.found == 3){
            DetectedObject = "Bow";
        }
        else if (select.found == 4){
            DetectedObject = "Axe";
        }
        else if (select.found == 5){
            DetectedObject = "Pick";
        }
        else if (select.found == 6){
            DetectedObject = "Rock";
        }
        else if (select.found == 7){
            DetectedObject = "Wooden";
        }
        else if (select.found == 8){
            DetectedObject = "BlueH";
        }
        else if (select.found == 9){
            DetectedObject = "RedH";
        }
        else{
            DetectedObject="";
        }
        Debug.Log(DetectedObject);
    }
}
 