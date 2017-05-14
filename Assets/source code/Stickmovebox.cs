using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Stickmovebox : MonoBehaviour
{
    
    static public float blockSpeed;
    void Start()
    {
        /* first block speed*/
        blockSpeed = 0.7f;
    }

    void Update()
    {
        /* Box move to player */
        gameObject.transform.position -= new Vector3(0f, 0f, blockSpeed);
        
        /* if player miss the box, fail. */
        if (transform.position.z < -8)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("restart_scene_stick");

        }
    }
 }
