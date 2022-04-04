using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAlienEnemy : Enemy
{
    // 1. Follow Plaer Around

    public float stopDistance; // This is for the Enemy to follow the Player ti a specific distance

    private float attackTime;
    public float attackSpeed;

    

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
            else
            {
                if(Time.time >= attackTime)
                {
                    //attack
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttackts;
                }
            }
        }
        
    }

    // IEnumerator is used like a Funktion
    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage); // The enemy will deal this amount of damage to the player

        Vector2 originalPos = transform.position;
        Vector2 targetPos = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4; //float formula will peorm the animation to going to the attack position and going back after attacking to the position the enemy had
            transform.position = Vector2.Lerp(originalPos, targetPos, formula);
            yield return null;

        }


    }
    
}
