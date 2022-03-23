using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAlienEnemy : Enemy
{
    // 1. Follow Plaer Around

    public float stopDistance; // This is for the Enemy to follow the Player ti a specific distance
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
        
    }
}
