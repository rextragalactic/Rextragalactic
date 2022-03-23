using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // What do we need to follow? 
    public Transform playerTransform;

    public float speed;

    

    // Start is called before the first frame update
    void Start()
    {
        // Camera is at the same position as our player
        transform.position = playerTransform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = Vector2.Lerp(transform.position, playerTransform.position, speed);

        }
    }
}
