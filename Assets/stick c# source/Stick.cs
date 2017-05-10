using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (StickCreator.Start_time <= 0)
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
        
        if (InputNetworkingManager.isConnected())
        {
            gameObject.transform.eulerAngles = new Vector3(90.0f - InputNetworkingManager.beta, 0f, InputNetworkingManager.alpha);
            gameObject.transform.position = new Vector3(InputNetworkingManager.x / 16.0f, InputNetworkingManager.y / 16.0f, InputNetworkingManager.z / 16.0f);
        }        
    }

    private void OnCollisionEnter(Collision col){

        if (col.gameObject.tag == "obstacle") {
            Destroy(col.gameObject);
            StickCreator.score++;
            //SceneManager.LoadScene("restart_scene");

        }

    }
}
