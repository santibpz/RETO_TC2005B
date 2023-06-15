using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitToEnd",40);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("Main_menu");
        }
    }

    public void WaitToEnd()
    {
        SceneManager.LoadScene("Main_menu");
    }
}
