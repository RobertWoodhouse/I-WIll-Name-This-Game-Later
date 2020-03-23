using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform leftClamp, rightClamp;
    public float playerSpeed;

    void FixedUpdate()
    {
        DebugControls();
    }

    void DebugControls()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) transform.position += Vector3.left * Time.deltaTime * playerSpeed;
        if(Input.GetKey(KeyCode.RightArrow)) transform.position += Vector3.right * Time.deltaTime * playerSpeed;
    }
}
