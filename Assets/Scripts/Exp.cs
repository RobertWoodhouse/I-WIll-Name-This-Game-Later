using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public float speed = 3.0f; // TODO change to random range

    [SerializeField]
    private Sprite _speedExpSprite, _powerExpSprite;
    private Sprite _defaultSpeedSprite, _defaultPowerSprite;
    private float _flashTimer;
    [SerializeField]
    private float _playerSpeedExp = 0.25f, _projectileSpeedExp = 10f, _projectileSpawnTimeExp = 0.050f; 

    public static Exp S;

    void Start()
    {
        S = this;
        _defaultSpeedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        _defaultPowerSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
       _flashTimer = 1.5f;
    }

    private void Update()
    {
        ExpFlash();
    }

    private void ExpFlash()
    {
        _flashTimer -= Time.deltaTime;

        if (_flashTimer < 1.5f && _flashTimer >= 1.0f && (gameObject.CompareTag("ExpPower") || gameObject.CompareTag("StarterExpPower")))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _powerExpSprite;
        }
        if (_flashTimer < 1.0f && (gameObject.CompareTag("ExpPower") || gameObject.CompareTag("StarterExpPower")))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _defaultPowerSprite;
            _flashTimer = 2.0f;
        }

        if (_flashTimer < 1.5f && _flashTimer >= 1.0f && (gameObject.CompareTag("ExpSpeed") || gameObject.CompareTag("StarterExpSpeed")))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _speedExpSprite;
        }
        if (_flashTimer < 1.0f && (gameObject.CompareTag("ExpSpeed") || gameObject.CompareTag("StarterExpSpeed")))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _defaultSpeedSprite;
            _flashTimer = 2.0f;
        }
    }

    public void SpeedUp() => GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerSpeed += _playerSpeedExp;

    public void PowerUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ProjectileController>().projectileSpeed += _projectileSpeedExp;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ProjectileController>().projectileSpawnTime -= _projectileSpawnTimeExp;
    }
}
