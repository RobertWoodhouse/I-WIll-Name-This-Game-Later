using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 leftBoundary, rightBoundary;
    public float playerSpeed, leftBound = -2.2f, rightBound = 2.2f;

    private void Start()
    {
        leftBoundary = new Vector3(leftBound, -4.0f, 0f);
        rightBoundary = new Vector3(rightBound, -4.0f, 0f);
    }

    void FixedUpdate()
    {
        DebugControls();
        Boundary(leftBound, rightBound);
    }

    void DebugControls()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) transform.position += Vector3.left * Time.deltaTime * playerSpeed;
        if(Input.GetKey(KeyCode.RightArrow)) transform.position += Vector3.right * Time.deltaTime * playerSpeed;
    }

    void TouchControls()
    {

    }

    private void Boundary(float left, float right)
    {
        //print("X pos = " + transform.position.x);
        if (transform.position.x <= left) transform.position = leftBoundary;
        if (transform.position.x >= right) transform.position = rightBoundary;
    }

    private void FireProjectile()
    {

    }
}
