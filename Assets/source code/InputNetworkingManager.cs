using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;
using UnityEngine.Networking;

public class InputNetworkingManager : MonoBehaviour {
    // Input network status
    private static int listenPort = 17778;
    private static bool serverOn = false;
    private static bool connected = false;
    private static WebSocketServer wssv;

    // stored sensor information
    public static float x { get; set; }
    public static float y { get; set; }
    public static float z { get; set; }
    public static float alpha { get; set; }
    public static float beta { get; set; }
    public static float gamma { get; set; }

    // define web socket behavior
    public class ProcessSensorInfo : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Debug.Log("WebSocket open");
            connected = true;
            CalibrationManager.setCalibrationOnProgress(true);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (!CalibrationManager.isCalibrated() && e.Data == "calibrate")
            {
                // if web socket receive calibrate command, then update calibration status
                CalibrationManager.setCalibrationOnProgress(false);
                CalibrationManager.setCalibrationDone();
                Debug.Log("Calibration Done");
            }
            else
            {
                // if web socket receive sensor information, update store the data
                string[] sensor_info = e.Data.Split(',');
                x = float.Parse(sensor_info[0]);
                y = float.Parse(sensor_info[1]);
                z = float.Parse(sensor_info[2]);
                alpha = float.Parse(sensor_info[3]);
                beta = float.Parse(sensor_info[4]);
                gamma = float.Parse(sensor_info[5]);
            }
        }

        protected override void OnError(ErrorEventArgs e)
        {
            Debug.LogError(e.Message);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Debug.Log("WebSocket closed");
            connected = false;
        }
    }

    public static int getListenPort()
    {
        return listenPort;
    }

    public static bool isConnected()
    {
        return connected;
    }

    public static void closeInputServer()
    {
        wssv.Stop();
    }

    // Use this for initialization
    void Start ()
    {
        // if web socket server is not open, open web socket server
        if (!serverOn)
        {
            wssv = new WebSocketServer("ws://" + Network.player.ipAddress + ":" + listenPort.ToString());
            wssv.AddWebSocketService<ProcessSensorInfo>("/ProcessSensorInfo");
            wssv.Start();
            serverOn = true;
        }
    }

    // Update is called once per frame
    void Update() { }
}
