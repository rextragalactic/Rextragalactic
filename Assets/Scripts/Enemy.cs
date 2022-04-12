using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // This Script is for all kind of enemies

    public int health;

    
    public Transform player;

    public float speed;

    public float timeBetweenAttackts;

    public int damage;

    public Rigidbody2D EnemyRigidbody2D;

  

    void Start()
    {
        //EnemyRigidbody2D = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        // If the health is smaller or equal to 0 - enemie dies - enemy game object will be destroyed
        if (health <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

}
