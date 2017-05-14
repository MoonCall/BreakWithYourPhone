using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class WebNetworkingManager : MonoBehaviour {
    // web server status 
    private static bool serverOn = false;

    private const string responseBodyPath = "Assets/responseBody.html";

    public static bool isServerOn()
    {
        return serverOn;
    }

    IEnumerator SetupWebServer()
    {
        if (!serverOn)
        {
            Debug.Log("SetupWebServer() called");

            // update web server status and wait for GUI update, then start web server
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://*:17777/");
            serverOn = true;
            yield return new WaitForFixedUpdate();
            listener.Start();

            // make response with responseBody.html and send response
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

            // close server and update status
            output.Close();
            listener.Stop();
            serverOn = false;
        }
    }

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnGUI()
    {
        string url = "http://" + Network.player.ipAddress + ":17777";

        // set style of web networking instruction message
        GUIStyle myStyle = new GUIStyle(GUI.skin.box);
        myStyle.fontSize = 25;
        myStyle.font = (Font)Resources.Load("NANUMBARUNGOTHICBOLD", typeof(Font));
        myStyle.normal.textColor = Color.white;

        // show server & connection status on screen
        if (serverOn)
            GUI.Box(new Rect(1, Screen.height - 90, Screen.width - 1, 90 - 1), "Connect " + url + " with your smartphone, using browser", myStyle);
        else if (InputNetworkingManager.isConnected())
            GUI.Box(new Rect(1, Screen.height - 90, Screen.width - 1, 90 - 1), "Smartphone Connection Done", myStyle);
        else
            GUI.Box(new Rect(1, Screen.height - 90, Screen.width - 1, 90 - 1), "Connection is not established. Open server and connect", myStyle);

        // if connection is not established, open server button appear
        if (!serverOn && !InputNetworkingManager.isConnected())
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 120, 200, 30 - 1), "Open Smartphone Input Server"))
                StartCoroutine(SetupWebServer());
    }
}
