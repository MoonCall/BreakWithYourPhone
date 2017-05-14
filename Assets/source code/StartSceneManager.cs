using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour {
    private static GameObject startButton;
    private static GameObject exitButton;
    public GameObject musicObject;


    // Use this for initialization
    void Start () {
        startButton = GameObject.Find("start_button");
        exitButton = GameObject.Find("exit_button");

        // limit frame to prevent obstacle speed being too fast
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;

        // create background music on start then maintain the BGM object even when scene change
        if (GameObject.FindGameObjectWithTag("BGM") == null)
        {
            GameObject obj = Instantiate(musicObject, new Vector3(0f, 0f, 0f), musicObject.transform.rotation);
            GameObject.DontDestroyOnLoad(obj);
        }
    }

    // Update is called once per frame
    void Update () {
        // if network is connected and calibration is done, then activate start & exit buttons
        if (!InputNetworkingManager.isConnected() || !CalibrationManager.isCalibrated()){
            startButton.SetActive(false);
            exitButton.SetActive(false);
        }
        else{
            startButton.SetActive(true);
            exitButton.SetActive(true);
        }
    }
}
