using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBuildScreen : MonoBehaviour
{
    GameObject BuildScreen;
    // Start is called before the first frame update
    void Start()
    {
        BuildScreen = GameObject.FindGameObjectWithTag("Build");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Close()
    {
        BuildScreen.SetActive(false);
    }
}
