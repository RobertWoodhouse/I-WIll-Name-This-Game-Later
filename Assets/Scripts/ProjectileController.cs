using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectileBullet, projectilePlasma, gunPos;
    public float projectileSpawnTime = 1.5f, projectileSpeed = 250.0f;// TODO increase speed with speed up

    private GameObject _projectileClone;
    private float _spawnTime, _doubleTapTime = 1.0f;
    private SpriteRenderer _sprite;
    private byte chargeColour = 128;


    private const float _minimumHeldDuration = 1.0f;
    private float _chargePressedTime = 0;
    private bool _chargeHeld = false;

    void Start()
    {
        if (gunPos == null) gunPos = gameObject;
        _spawnTime = projectileSpawnTime;
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
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
            // Use has pressed the Space key. We don't know if they'll release or hold it, so keep track of when they started holding it.

            _spawnTime = projectileSpawnTime;
            _projectileClone = Instantiate(projectileBullet, gunPos.transform.position, gunPos.transform.rotation);
            _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
            _projectileClone.GetComponent<AudioSource>().Play();

            _chargePressedTime = Time.timeSinceLevelLoad;
            _chargeHeld = false;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (_chargeHeld)
            {
                _spawnTime = projectileSpawnTime;
                _projectileClone = Instantiate(projectilePlasma, gunPos.transform.position, gunPos.transform.rotation);
                _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
                _projectileClone.GetComponent<AudioSource>().Play();
                print("FIRE PLASMA!!");
                _chargePressedTime = Time.timeSinceLevelLoad;
            }
            if (!_chargeHeld && _spawnTime <= 0)
            {
                // Player has released the space key without holding it.
                // TODO: Perform the action for when Space is pressed.

                _spawnTime = projectileSpawnTime;
                _projectileClone = Instantiate(projectileBullet, gunPos.transform.position, gunPos.transform.rotation);
                _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
                _projectileClone.GetComponent<AudioSource>().Play();
                _chargePressedTime = Time.timeSinceLevelLoad;
            }

            _sprite.color = new Color32(255, 255, 255, 255);
            _chargeHeld = false;
        }

        if (Input.GetButton("Fire1"))
        {
            //print("Time Since Level Load - Charge Pressed Time " + (Time.timeSinceLevelLoad - _chargePressedTime) + " Minimum Held Duration " + _minimumHeldDuration);

            //_sprite.color = new Color32(255, 255, chargeColour, 255);

            if ((Time.timeSinceLevelLoad - _chargePressedTime) > _minimumHeldDuration)
            {
                //print("Charge Colour = " + chargeColour);
                float chargeColourConvert = chargeColour;
                if (chargeColour >= 1) chargeColourConvert -= (Time.deltaTime * 256);
                if (chargeColour < 1) chargeColourConvert = 255;
                chargeColour = (byte)chargeColourConvert;
                _sprite.color = new Color32(255, 255, chargeColour, 255);

                // Player has held the Space key for .25 seconds. Consider it "held"
                Debug.Log("SHOT CHARGED");
                _chargeHeld = true;

            }
        }
    }

    void FireProjectileTouchScreen()
    {
        if (_spawnTime > 0) _spawnTime -= Time.deltaTime; // Fire Rate

        if ((Input.touchCount > 0))
        //if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit != null && hit.collider != null)
            {
                Debug.Log("I'm hitting " + hit.collider.name);
                //if (Input.GetButtonDown("Fire1") && hit.collider.CompareTag("Player") && _spawnTime < 0)
                if ((Input.GetTouch(0).phase == TouchPhase.Began) && hit.collider.CompareTag("Player") && _spawnTime < 0)
                {
                    Debug.Log("Ship Selected");

                    _spawnTime = projectileSpawnTime;
                    _projectileClone = Instantiate(projectileBullet, gunPos.transform.position, gunPos.transform.rotation);
                    _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
                    _projectileClone.GetComponent<AudioSource>().Play();

                    _chargePressedTime = Time.timeSinceLevelLoad;
                    _chargeHeld = false;
                }

                //if (Input.GetButton("Fire1") && hit.collider.CompareTag("Player"))
                if (Input.GetTouch(0).phase == TouchPhase.Stationary && hit.collider.CompareTag("Player"))
                {
                    if ((Time.timeSinceLevelLoad - _chargePressedTime) > _minimumHeldDuration)
                    {
                        print("Charge Colour = " + chargeColour);
                        float chargeColourConvert = chargeColour;
                        if (chargeColour >= 1) chargeColourConvert -= (Time.deltaTime * 256); // FIXME 256?
                        if (chargeColour < 1) chargeColourConvert = 255;
                        chargeColour = (byte)chargeColourConvert;
                        _sprite.color = new Color32(255, 255, chargeColour, 255);

                        // Player has held the Space key for .25 seconds. Consider it "held"
                        Debug.Log("SHOT CHARGED");
                        _chargeHeld = true;

                    }
                }
            }

            //if (Input.GetButtonUp("Fire1"))
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (_chargeHeld)
                {
                    _spawnTime = projectileSpawnTime;
                    _projectileClone = Instantiate(projectilePlasma, gunPos.transform.position, gunPos.transform.rotation);
                    _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
                    _projectileClone.GetComponent<AudioSource>().Play();
                    print("FIRE PLASMA!!");
                    _chargePressedTime = Time.timeSinceLevelLoad;
                }
                if (!_chargeHeld && _spawnTime <= 0)
                {
                    // Player has released the space key without holding it.
                    // TODO: Perform the action for when Space is pressed.

                    _spawnTime = projectileSpawnTime;
                    _projectileClone = Instantiate(projectileBullet, gunPos.transform.position, gunPos.transform.rotation);
                    _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
                    _projectileClone.GetComponent<AudioSource>().Play();
                    _chargePressedTime = Time.timeSinceLevelLoad;
                }

                _sprite.color = new Color32(255, 255, 255, 255);
                _chargeHeld = false;
            }
        }

        /*
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
                _projectileClone = Instantiate(projectileBullet, gunPos.transform.position, gunPos.transform.rotation);
                _projectileClone.GetComponent<Rigidbody2D>().AddForce(gunPos.transform.up * projectileSpeed);
                _projectileClone.GetComponent<AudioSource>().Play();
            }

            //_doubleTapTime = 1.0f;
            //print("Double tap time reset " + _doubleTapTime);
            
            if (touch.phase == TouchPhase.Ended)
            {
                _doubleTapTime = 0.25f;
            }
        }
        */
    }
}