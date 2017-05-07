using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour {
    private static GameObject startButton;

	// Use this for initialization
	void Start () {
        startButton = GameObject.Find("start_button");
    }
	
	// Update is called once per frame
	void Update () {
        if (!InputNetworkingManager.isConnected() || !CalibrationManager.isCalibrated())
            startButton.SetActive(false);
        else
            startButton.SetActive(true);
    }
}
