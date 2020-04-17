using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed, leftBound = -1.7f, rightBound = 1.7f;
    public GameObject goAfterBurner;

    private Animator _animShip, _animAfterburner;
    private Vector3 _leftBoundary, _rightBoundary;

    private void Start()
    {
        if (goAfterBurner == null) goAfterBurner = GameObject.Find("Afterburner");
        _animShip = GetComponent<Animator>();
        _animAfterburner = goAfterBurner.GetComponent<Animator>();
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
            _animShip.SetBool("isStrafeLeft", true);
            _animAfterburner.SetBool("isMoving", true);
            transform.position += Vector3.left * Time.deltaTime * playerSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ///print("Reset left animations");
            _animShip.SetBool("isStrafeLeft", false);
            if (_animShip.GetBool("isStrafeRight")) _animShip.SetBool("isStrafeRight", false);
            _animAfterburner.SetBool("isMoving", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _animShip.SetBool("isStrafeRight", true);
            _animAfterburner.SetBool("isMoving", true);
            transform.position += Vector3.right * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //print("Reset right animations");
            _animShip.SetBool("isStrafeRight", false);
            if (_animShip.GetBool("isStrafeLeft")) _animShip.SetBool("isStrafeLeft", false);
            _animAfterburner.SetBool("isMoving", false);
        }
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
}
