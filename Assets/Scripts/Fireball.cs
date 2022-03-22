using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    // How long is the fireball going to stay in the game
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy Fireball after Life Time has passed
        DestroyObject(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
