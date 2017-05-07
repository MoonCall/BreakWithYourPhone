using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void start_button()
    {
        SceneManager.LoadScene("play_scene");       
    }

    public void restart_button()
    {
        SceneManager.LoadScene("start_scene");
        
    }

}
