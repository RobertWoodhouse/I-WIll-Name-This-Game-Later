using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectileType, gunPos;
    public float projectileSpawnTime = 1.5f, projectileFireRate, projectileSpeed = 250.0f;

    private GameObject _projectileClone;
    private float _spawnTime;

    void Start()
    {
        if (gunPos == null) gunPos = gameObject;
        _spawnTime = projectileSpawnTime;
    }

    void FixedUpdate()
    {
        FireRate();
    }

    void FireRate()
    {
        if (_spawnTime > 0) _spawnTime -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && _spawnTime < 0)
        {
            //print("MORE FIRE!!");
            _spawnTime = projectileSpawnTime;
            _projectileClone = Instantiate(projectileType, gunPos.transform.position, gunPos.transform.rotation);
            _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
            _projectileClone.GetComponent<AudioSource>().Play();
        }
    }
}
