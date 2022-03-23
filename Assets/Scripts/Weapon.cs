using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //The Object that will be visable when the Player shoots
    public GameObject fireball;
    // The Position where the Fireball will apear
    public Transform shotPoint;
    public float timeBetweenShots;

    private float shotTime;

    // Update is called once per frame
    void Update()
    {
        // = Direction Between Mouse position and Weapons position (Mouse Position - Weapon position) 
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // Transform direction into an angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Transform the Angle into an Unity Rotation
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // position weapon = new Unity rotation
        transform.rotation = rotation;

        // Checking if the Imput (Mouse Button) is 0
        if (Input.GetMouseButton(0))
        {
            
            // Current time in the game 
            if (Time.time >= shotTime)
                {

                //Instantiate(fireball, shotPoint.transform.position, shotPoint.transform.rotation);

                // (What am I spawing, at what position, at what rotation)
                Instantiate(fireball, shotPoint.position, transform.rotation);

                shotTime = Time.time + timeBetweenShots;
                }
            }
        }
    }
