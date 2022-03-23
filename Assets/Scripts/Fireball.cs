using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;

    // How long is the fireball going to stay in the game
    public float lifeTime;

    public GameObject explosion;

    // Start is called before the first frame update
    private void Start()
    {
        //Destroy Fireball after Life Time has passed
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        // (What am I spawing, at what position, at what rotation)
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
