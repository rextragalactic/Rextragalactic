using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // What do we need to follow? 
    public Transform playerTransform;

    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

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
            // This makes the camera background "disapear" so that we only see the game background 
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);

            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX,clampedY), speed);

        }
    }
}
