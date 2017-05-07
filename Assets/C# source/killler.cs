using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Creator.Start_time <= 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -5)
            {
                gameObject.transform.position -= new Vector3(0.2f, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 5)
            {
                gameObject.transform.position += new Vector3(0.2f, 0f, 0f);
            }
        }
        
    }

    private void OnCollisionEnter(Collision col){

        if (col.gameObject.tag == "obstacle") {
            Destroy(gameObject);
            SceneManager.LoadScene("restart_scene");

        }

    }
}
