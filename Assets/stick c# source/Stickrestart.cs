using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stickrestart : MonoBehaviour {

    int last_score;

	// Use this for initialization
	void Start () {
        last_score = 0 ;
    }

    private void Update()
    {
        
        last_score = StickCreator.score;
    }


    void OnGUI()
    {
        GUIStyle Scorestyle = new GUIStyle(GUI.skin.label);
        Scorestyle.fontSize = 30;
        
        

        GUI.Label(new Rect(transform.position.x, transform.position.y, 480, 100), "Score    :   " + last_score, Scorestyle);

    }
}
