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

    public void start_button()
    {
        SceneManager.LoadScene("play_scene_stick");       
    }

    public void restart_button()
    {
        SceneManager.LoadScene("start_scene_stick");
        
    }

}
