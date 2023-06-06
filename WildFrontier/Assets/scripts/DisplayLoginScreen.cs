using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayLoginScreen : MonoBehaviour
{
    public void OpenLogin()
    {
        SceneManager.LoadScene("Log_in");
    }
}
