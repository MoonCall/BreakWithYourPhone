using UnityEngine;
using System.Collections;

public class movebox : MonoBehaviour
{


    void Start()
    {
        gameObject.name = "movebox";
    }

    void Update()
    {
        gameObject.transform.position -= new Vector3(0f, 0f, 1f);


        if (transform.position.z == 15)
            Creator.score++; ;


        if (transform.position.z < -8)
        {
            Destroy(gameObject);
            
        }

    }
 }
