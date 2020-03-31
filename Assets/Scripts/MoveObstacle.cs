using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float randLower = 20f, randUpper = 40f;
    public bool isRotate = false;

    [SerializeField]
    private float _movementSpeed = 5.0f;
    private Vector3 _rotateObstacle;


    private void Start()
    {
        _movementSpeed = this.GetComponent<Obstacle>().speed;
    }

    void FixedUpdate()
    {
        Move(_movementSpeed);
        Rotate(isRotate);
    }

    public void Move(float speed) => transform.position += Vector3.down * Time.deltaTime * speed;

    public void Rotate(bool rotateObject)
    {
        if (rotateObject) transform.Rotate(_rotateObstacle = new Vector3(0f,0f,Random.Range(randLower, randUpper)) * Time.deltaTime);
    }
}
