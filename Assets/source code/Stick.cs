using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stick : MonoBehaviour {
    public AudioClip destroySound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /* move the stick with sensor info*/
        if (InputNetworkingManager.isConnected())
        {
            gameObject.transform.eulerAngles = new Vector3(90.0f - InputNetworkingManager.beta, 0f, InputNetworkingManager.alpha);
            gameObject.transform.position = new Vector3(InputNetworkingManager.x / 20.0f, InputNetworkingManager.y / 20.0f, InputNetworkingManager.z / 20.0f);
        }        
    }

    private void OnCollisionEnter(Collision col){

        /* destroy the obstacle */
        if (col.gameObject.tag == "obstacle") {
            Destroy(col.gameObject);
            StickCreator.score++;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(destroySound);

        }

    }
}
