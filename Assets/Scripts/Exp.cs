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
        _defaultSpeedSprite = GetComponent<SpriteRenderer>().sprite;
        _defaultPowerSprite = GetComponent<SpriteRenderer>().sprite;
       _flashTimer = 1.5f;
    }

    private void Update()
    {
        ExpFlash();
    }

    private void ExpFlash()
    {
        _flashTimer -= Time.deltaTime;

        if (_flashTimer < 1.5f && _flashTimer >= 1.0f && (CompareTag("ExpPower") || CompareTag("StarterExpPower")))
        {
            GetComponent<SpriteRenderer>().sprite = _powerExpSprite;
        }
        if (_flashTimer < 1.0f && (CompareTag("ExpPower") || CompareTag("StarterExpPower")))
        {
            GetComponent<SpriteRenderer>().sprite = _defaultPowerSprite;
            _flashTimer = 2.0f;
        }

        if (_flashTimer < 1.5f && _flashTimer >= 1.0f && (CompareTag("ExpSpeed") || CompareTag("StarterExpSpeed")))
        {
            GetComponent<SpriteRenderer>().sprite = _speedExpSprite;
        }
        if (_flashTimer < 1.0f && (CompareTag("ExpSpeed") || CompareTag("StarterExpSpeed")))
        {
            GetComponent<SpriteRenderer>().sprite = _defaultSpeedSprite;
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
