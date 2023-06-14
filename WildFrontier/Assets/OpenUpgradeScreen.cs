using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgradeScreen : MonoBehaviour
{
    [SerializeField] GameObject UpgradeScreen;
    public void Display()
    {
        Time.timeScale = 0;
        UpgradeScreen.SetActive(true);
    }
}
