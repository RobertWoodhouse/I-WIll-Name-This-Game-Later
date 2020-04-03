using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Animator anim;
    public float playerSpeed, leftBound = -1.7f, rightBound = 1.7f;

    private Animator _animShip;
    private Vector3 _leftBoundary, _rightBoundary;

    private void Start()
    {
        _animShip = GetComponent<Animator>();
        _leftBoundary = new Vector3(leftBound, -4.0f, 0f);
        _rightBoundary = new Vector3(rightBound, -4.0f, 0f);
    }

    void FixedUpdate()
    {
        DebugControls();
        Boundary(leftBound, rightBound);
    }

    void DebugControls()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * playerSpeed;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * playerSpeed;
            _animShip.SetBool("ifStrafeRight", true);
        }
        else _animShip.SetBool("ifStrafeRight", false);
    }

    void TouchControls()
    {

    }

    private void Boundary(float left, float right)
    {
        //print("X pos = " + transform.position.x);
        if (transform.position.x <= left) transform.position = _leftBoundary;
        if (transform.position.x >= right) transform.position = _rightBoundary;
    }

    private void FireProjectile()
    {

    }
}
