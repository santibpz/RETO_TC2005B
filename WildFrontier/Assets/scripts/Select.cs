using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float rlimit;
    [SerializeField] float llimit;
    Vector3 move;
    RectTransform selectionrect;

    // Start is called before the first frame update
    void Start()
    {
        selectionrect=GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            float newX = selectionrect.localPosition.x - distance;
            if (newX >= llimit)
            {
                selectionrect.localPosition = new Vector3(newX, selectionrect.localPosition.y);
            }
            else 
            {
                selectionrect.localPosition = new Vector3(rlimit, selectionrect.localPosition.y);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            float newX = selectionrect.localPosition.x + distance;
            if (newX <= rlimit)
            {
                selectionrect.localPosition = new Vector3(newX, selectionrect.localPosition.y);
            }
            else 
            {
                selectionrect.localPosition = new Vector3(llimit, selectionrect.localPosition.y);
            }
        }
    }
}
