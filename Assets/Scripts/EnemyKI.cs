using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKI : MonoBehaviour
{


    public float speed = 3f;

    // Move arround randomly
    private EnemyPath pathMovement;
    private Vector3 startingPos;
    private Vector3 roamPosition;

    private Transform target;

    [SerializeField]
    private float attackDamage = 10f;

    [SerializeField]
    private float attackSpeed = 1f;

    private float canAttack;

    private void Awake()
    {
        pathMovement = GetComponent<EnemyPath>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        float reacherPositionDistance = 1f;

        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        else if (Vector3.Distance(transform.position, roamPosition) < reacherPositionDistance)
        {
            // Reached Roam Position
            roamPosition = GetRoamingPosition();

        }



    }

    // Methode to get a Random position 
    private Vector3 GetRoamingPosition()
    {
        return startingPos + GetRandomDirection() * Random.Range(10f, 70f);
    }


    // Generate random normalized direction
    public static Vector3 GetRandomDirection()
    {
        // Random on x, Random on y and normalized the Vector
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    


}


