using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stickbuttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {            
    }

    /* Start button function*/
    public void start_button()
    {
        SceneManager.LoadScene("play_scene_stick");       
    }
    /* Restart button function*/
    public void restart_button()
    {
        SceneManager.LoadScene("start_scene_stick");
        
    }
    /* Exit button function*/
    public void exit_button()
    {
        Application.Quit();
    }

}
