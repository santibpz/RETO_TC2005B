using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayInitialScreen : MonoBehaviour
{
    public void OpenInitial()
    {
        SceneManager.LoadScene("Initial");
    }
}
