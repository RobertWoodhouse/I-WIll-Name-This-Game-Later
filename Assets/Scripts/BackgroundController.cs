using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Color bgColour;
    public GameObject stars1, stars2, parallax1, parallax2, shipPos;

    [SerializeField]
    private float _fadeAlpha = 255;

    void Start()
    {
        if (shipPos == null) shipPos = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        BackgroundStarsSparkle();
        BackgroundParallaxHorizontal();
    }

    void BackgroundParallaxHorizontal()
    {
        parallax1.transform.position = new Vector3(shipPos.transform.position.x * -0.01f, 0, 0);
        parallax2.transform.position = new Vector3(shipPos.transform.position.x * -0.04f, 0, 0);
    }


    void BackgroundStarsSparkle()
    {
        _fadeAlpha -= Time.deltaTime;

        stars1.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 155));
        stars2.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 105));
    }
}
