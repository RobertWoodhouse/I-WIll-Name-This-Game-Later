using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float movementSpeed = 2.0f;

    void FixedUpdate()
    {
        Move(movementSpeed);
    }

    public void Move(float speed) => transform.position += Vector3.down * Time.deltaTime * speed;
}
