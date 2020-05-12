using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public float speed = 3.0f; // TODO change to random range

    public static Exp S;

    void Start()
    {
        S = this;
    }

    public void SpeedUp() => GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerSpeed += 0.25f;

    public void PowerUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ProjectileController>().projectileSpeed += 10f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ProjectileController>().projectileSpawnTime -= 0.050f;
    }
}
