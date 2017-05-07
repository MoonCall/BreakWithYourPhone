using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationManager : MonoBehaviour {
    private static bool calibrationDone = false;
    private static bool onProgress = false;
    private static GameObject instructionImage;

    // Use this for initialization
    void Start () {
        instructionImage = GameObject.Find("instruction_image");
        instructionImage.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static bool isCalibrated()
    {
        return calibrationDone;
    }

    public static void setCalibrationOnProgress(bool prog)
    {
        onProgress = prog;
    }

    public static void setCalibrationDone()
    {
        calibrationDone = true;
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.box);
        myStyle.fontSize = 25;
        myStyle.font = (Font)Resources.Load("NANUMBARUNGOTHICBOLD", typeof(Font));
        myStyle.normal.textColor = Color.white;

        if (onProgress)
        {
            if (!instructionImage.active)
                instructionImage.SetActive(true);
            GUI.Box(new Rect(Screen.width / 2 - 600, Screen.height - 200, 1200, 80 - 1), "Calibration on Progress: set phone's position like image", myStyle);
        }
        else
        {
            if (instructionImage.active)
                instructionImage.SetActive(false);
        }
        /*
        else
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 150, 200, 30 - 1), "Start Calibration"))
                StartCoroutine(Calibrate());
        }
        */
    }
}
