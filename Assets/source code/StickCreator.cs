using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class StickCreator : MonoBehaviour {

    /* spawned object is source */
    public GameObject source;
    //public GameObject source2;

    /*Timers*/
    float Timer;
    static public float Start_time ;
    int speed_up = 0;
    int last_update = 0;

    /* Spawn position */
    float position_x;
    const float position_y = -1;
    const float position_z = 70;

    /* info in game */
    public float Max_TIME;
    static public int score;
    
    bool Is_speed_up;

    // Use this for initialization
    void Start () {

        Timer = Random.Range(0.3f,Max_TIME);
        Start_time = 2;
        score = 0;
        Is_speed_up = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Start_time > 0)
        {
            Start_time -= Time.deltaTime;  /* before start, give time to ready */
        }
        else
        {
            Timer -= Time.deltaTime;   /* delay spawn between two blocks  */
            position_x = Random.Range(-4.5f, 4.5f);
            if (Timer <= 0)
            {
                Instantiate(source, new Vector3(position_x, transform.position.y, position_z), source.transform.rotation);

                Timer = Random.Range(0.3f, Max_TIME);
                if (Max_TIME > 0.3) /* Minimum respawn interval is 0.3 */
                {
                    Is_speed_up = score % 5 == 0 && (last_update != score);
                    if (Is_speed_up) /* speed up and reduce respawn time interval */
                    {
                        Max_TIME *= 0.9f;
                        Stickmovebox.blockSpeed += 0.01f;
                        speed_up = 50;
                        last_update = score;
                        Debug.Log(Max_TIME);
                    }
                }
            }

        }
    }

    // show status on screen according to game status
    void OnGUI()
    {
        GUIStyle mystyle = new GUIStyle(GUI.skin.label);
        mystyle.fontSize = 50;

        GUI.Label(new Rect(100, 100, 500, 70),"Score : " + score.ToString(),mystyle);

        if (Start_time > 0)
        {
            GUI.Label(new Rect(400, 350, 500, 70), "Let's start!", mystyle);
        }

        if (speed_up > 0) {
            GUI.Label(new Rect(700, 100, 500, 70), "Speed UP!", mystyle);
            speed_up--;
        }
    }
}
