﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float randLower = 20f, randUpper = 40f;
    public bool isRotate = false;

    private Vector3 _rotateObstacle;

    private void Update()
    {
        if (CompareTag("ExpSpeed") || CompareTag("ExpPower")) Move(GetComponent<Exp>().speed);
        if (CompareTag("Obstacle")) Move(GetComponent<Obstacle>().speed);
    }

    void FixedUpdate()
    {
        Rotate(isRotate);
    }

    public void Move(float speed) => transform.position += Vector3.down * Time.deltaTime * speed;

    public void Rotate(bool rotateObject)
    {
        if (rotateObject) transform.Rotate(new Vector3(0f,0f,Random.Range(randLower, randUpper)) * Time.deltaTime);
    }
}
