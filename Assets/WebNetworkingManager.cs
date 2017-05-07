using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class WebNetworkingManager : MonoBehaviour {
    private static bool connecting = false;
    private static bool serverOn = false;
    private const string responseBodyPath = "Assets/responseBody.html";

    public static bool isConnecting()
    {
        return connecting;
    }

    public static bool isServerOn()
    {
        return serverOn;
    }

    IEnumerator SetupWebServer()
    {
        if (!serverOn)
        {
            Debug.Log("SetupWebServer() called");
            connecting = true;
            yield return new WaitForFixedUpdate();
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://*:17777/");
            listener.Start();
            serverOn = true;
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            if (!System.IO.File.Exists(responseBodyPath))
                Debug.LogError("responseBody not found");

            string responseString = System.IO.File.ReadAllText(responseBodyPath)
                .Replace("REPLACE_THIS_IP_ADDR", Network.player.ipAddress)
                .Replace("REPLACE_THIS_PORT", InputNetworkingManager.getListenPort().ToString());
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();
            listener.Stop();
            serverOn = false;
            connecting = false;
        }
    }

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnGUI()
    {
        string url = "http://" + Network.player.ipAddress + ":17777";
        GUIStyle myStyle = new GUIStyle(GUI.skin.box);
        myStyle.fontSize = 25;
        myStyle.font = (Font)Resources.Load("NANUMBARUNGOTHICBOLD", typeof(Font));
        myStyle.normal.textColor = Color.white;

        // show server status
        if (connecting)
            GUI.Box(new Rect(1, Screen.height - 90, Screen.width - 1, 90 - 1), "Connect " + url + " with your smartphone, using browser", myStyle);
        else if (InputNetworkingManager.isConnected())
            GUI.Box(new Rect(1, Screen.height - 90, Screen.width - 1, 90 - 1), "Smartphone Connection Done", myStyle);
        else
            GUI.Box(new Rect(1, Screen.height - 90, Screen.width - 1, 90 - 1), "Connection is not established. Open server and connect", myStyle);

        // if connection failed, reopen server button appear
        if (!serverOn && !InputNetworkingManager.isConnected())
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 120, 200, 30 - 1), "Open Smartphone Input Server"))
                StartCoroutine(SetupWebServer());
    }
}
