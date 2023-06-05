using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplaySignupScreen : MonoBehaviour
{
    public void OpenSignup()
    {
        SceneManager.LoadScene("Sign_up");
    }
}
