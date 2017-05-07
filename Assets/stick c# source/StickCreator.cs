using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class StickCreator : MonoBehaviour {

    public GameObject source;
    
    float Timer;
    static public float Start_time ;

    float position_x;
    const float position_y = -1;
    const float position_z = 70;
    public float Max_TIME;
    static public int score;

    int speed_up;
    bool Is_speed_up;
    bool Is_up;

    // Use this for initialization
    void Start () {

        Timer = Max_TIME;
        Start_time = 2;
        score = 0;
        Is_speed_up = false;
        Is_up = false;
    }
	
	// Update is called once per frame
	void Update () {

       
        if (Start_time > 0)
        {
            Start_time -= Time.deltaTime;
        }
        else
        {
            Timer -= Time.deltaTime;
            position_x = Random.Range(-4.5f, 4.5f);
            if (Timer <= 0)
            {
                Instantiate(source, new Vector3(position_x, position_y, position_z), transform.rotation);

                Timer = Max_TIME;
                if (Max_TIME > 0.3)
                {
                    Is_speed_up = score % 20 == 0 && score != 0 && !Is_up;
                    if (Is_speed_up)
                    {

                        Max_TIME *= 0.9f;
                        Is_up = true;
                        Debug.Log(Max_TIME);
                    }
                    else
                    {
                        Is_up = false;
                    }
                }
                

            }

        }
    }

    void OnGUI()
    {
        GUIStyle mystyle = new GUIStyle(GUI.skin.label);
        mystyle.fontSize = 50;
        GUI.Label(new Rect(100, 100, 500, 70),"Score : " + score.ToString(),mystyle);

        GUIStyle mystyle2 = new GUIStyle(GUI.skin.label);
        mystyle2.fontSize = 50;

        GUIStyle mystyle3 = new GUIStyle(GUI.skin.label);
        mystyle3.fontSize = 50;


        if (Start_time > 0)
        {
            GUI.Label(new Rect(400, 350, 500, 70), "Let's start!", mystyle2);
        }

        if (Is_speed_up)
        {
           speed_up= 50;
        }

        if (speed_up > 0) {
            GUI.Label(new Rect(700, 100, 500, 70), "Speed UP!", mystyle2);
            speed_up--;
        }

    }


}
