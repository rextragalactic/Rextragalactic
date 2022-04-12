using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastAIScript : MonoBehaviour
{
    public float speed;
    private WayPoints Wpoints;

    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<WayPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.wayPoints[waypointIndex].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, Wpoints.wayPoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;

        }
    }
}
