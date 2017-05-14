using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationManager : MonoBehaviour {
    // calibration status
    private static bool calibrationDone = false;
    private static bool onProgress = false;

    private static GameObject instructionImage;

    // Use this for initialization
    void Start ()
    {
        // initialize and deactive instructionImage 
        instructionImage = GameObject.Find("instruction_image");
        instructionImage.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

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
        // set style of instruction message
        GUIStyle myStyle = new GUIStyle(GUI.skin.box);
        myStyle.fontSize = 25;
        myStyle.font = (Font)Resources.Load("NANUMBARUNGOTHICBOLD", typeof(Font));
        myStyle.normal.textColor = Color.white;

        // if calibration is on progress, show calibration instruction image
        if (onProgress)
        {
            if (!instructionImage.activeSelf)
                instructionImage.SetActive(true);
            GUI.Box(new Rect(Screen.width / 2 - 600, Screen.height - 200, 1200, 80 - 1), "Calibration on Progress: set phone's position like image", myStyle);
        }
        else
        {
            if (instructionImage.activeSelf)
                instructionImage.SetActive(false);
        }
    }
}
