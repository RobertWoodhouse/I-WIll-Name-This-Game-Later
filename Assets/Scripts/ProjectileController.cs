using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectileType, gunPos;
    public float projectileSpawnTime = 1.5f, projectileSpeed = 250.0f;// TODO increase speed with speed up

    private GameObject _projectileClone;
    private float _spawnTime, _doubleTapTime = 1.0f;


    void Start()
    {
        if (gunPos == null) gunPos = gameObject;
        _spawnTime = projectileSpawnTime;
    }

    void FixedUpdate()
    {
    #if UNITY_EDITOR
        FireProjectileDebug();
    #endif

    #if UNITY_ANDROID
        FireProjectileTouchScreen();
    #endif
    }

    public void FireProjectileDebug()
    {
        if (_spawnTime > 0) _spawnTime -= Time.deltaTime; // Fire Rate

        if (Input.GetButtonDown("Fire1") && _spawnTime <= 0)
        {
            //print("MORE FIRE!!");
            _spawnTime = projectileSpawnTime;
            _projectileClone = Instantiate(projectileType, gunPos.transform.position, gunPos.transform.rotation);
            _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
            _projectileClone.GetComponent<AudioSource>().Play();
        }
    }

    void FireProjectileTouchScreen()
    {
        if (_spawnTime > 0) _spawnTime -= Time.deltaTime; // Fire Rate
        if (_doubleTapTime > 0 )_doubleTapTime -= Time.deltaTime;
        //print("Double tap time " + _doubleTapTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Getting the zero'th touch, first touch

            if (_doubleTapTime > 0 && _spawnTime <= 0)
            {
                //print("MORE FIRE!!");
                _spawnTime = projectileSpawnTime;
                _projectileClone = Instantiate(projectileType, gunPos.transform.position, gunPos.transform.rotation);
                _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
                _projectileClone.GetComponent<AudioSource>().Play();
            }

            //_doubleTapTime = 1.0f;
            //print("Double tap time reset " + _doubleTapTime);
            
            if (touch.phase == TouchPhase.Ended)
            {
                _doubleTapTime = 0.5f;
            }
        
        }
    }
}