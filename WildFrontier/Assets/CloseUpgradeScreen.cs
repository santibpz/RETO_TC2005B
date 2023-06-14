using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpgradeScreen : MonoBehaviour
{
    [SerializeField] GameObject UpgradeScreen;

    public void Close()
    {
        UpgradeScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
