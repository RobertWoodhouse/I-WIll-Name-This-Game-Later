using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public float speed = 3.0f; // TODO change to random range

    [SerializeField]
    private Sprite _speedExpSprite, _powerExpSprite;
    private Sprite _defaultSpeedSprite, _defaultPowerSprite;
    private float _timer;

    public static Exp S;

    void Start()
    {
        S = this;
        _defaultSpeedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        _defaultPowerSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
       _timer = 1.5f;
    }

    private void Update()
    {
        ExpFlash();
    }

    private void ExpFlash()
    {
        _timer -= Time.deltaTime;

        if (_timer < 1.5f && _timer >= 1.0f && (gameObject.CompareTag("ExpPower") || gameObject.CompareTag("StarterExpPower")))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _powerExpSprite;
        }
        if (_timer < 1.0f && (gameObject.CompareTag("ExpPower") || gameObject.CompareTag("StarterExpPower")))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _defaultPowerSprite;
            _timer = 2.0f;
        }

        if (_timer < 1.5f && _timer >= 1.0f && (gameObject.CompareTag("ExpSpeed") || gameObject.CompareTag("StarterExpSpeed")))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _speedExpSprite;
        }
        if (_timer < 1.0f && (gameObject.CompareTag("ExpSpeed") || gameObject.CompareTag("StarterExpSpeed")))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _defaultSpeedSprite;
            _timer = 2.0f;
        }
    }

    public void SpeedUp() => GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerSpeed += 0.25f;

    public void PowerUp()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ProjectileController>().projectileSpeed += 10f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ProjectileController>().projectileSpawnTime -= 0.050f;
    }
}
