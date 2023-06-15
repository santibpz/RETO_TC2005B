using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over_manager : MonoBehaviour
{
    MusicManager music;

    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.Find("MusicManager").GetComponent<MusicManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gamescene(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
        music.CheckTransitionToGameMusic();
    }

}
