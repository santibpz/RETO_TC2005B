using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuildScreen : MonoBehaviour
{
    [SerializeField] GameObject BuildScreen;

    public void Display()
    {
        BuildScreen.SetActive(true);
    }
}
