using System;
using UnityEngine;

public class EnemyMovement
{
    public static void MoveEnemy(Rigidbody2D rb, Vector3 destination, Vector3 enemyPosition, float speed)
    {
        Rotate(rb, destination, enemyPosition);
        Move(rb, destination, enemyPosition, speed);

    }

    private static void Rotate(Rigidbody2D rb, Vector3 destination, Vector3 enemyPosition)
    {
        var direction = (destination - enemyPosition).normalized;

        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.SetRotation(rotationZ - 90);

    }

    private static void Move(Rigidbody2D rb, Vector3 destination, Vector3 enemyPosition, float speed)
    {
        var direction = (destination - enemyPosition).normalized;
        rb.velocity = direction * speed * Time.deltaTime;
    }


}
