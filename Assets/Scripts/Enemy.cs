using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // This Script is for all kind of enemies

    public int health;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        // If the health is smaller or equal to 0 - enemie dies - enemy game object will be destroyed
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
