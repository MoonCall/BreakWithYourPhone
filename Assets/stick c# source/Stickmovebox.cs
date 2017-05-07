using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Stickmovebox : MonoBehaviour
{


    void Start()
    {
        gameObject.name = "movebox";
    }

    void Update()
    {
        gameObject.transform.position -= new Vector3(0f, 0f, 1f);

        if (transform.position.z < -8)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("restart_scene_stick");

        }

    }
 }
