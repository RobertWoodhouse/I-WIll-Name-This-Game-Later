using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Color bgColour;
    public GameObject bgStars1, bgStars2, bgParallax1, bgParallax2, bgStarsEnd1, bgStarsEnd2, bgParallaxEnd1, bgParallaxEnd2, shipPos;

    [SerializeField]
    private float _fadeAlpha = 255, _scrollYStartPos = 0;
    private float _scrollYEndPos;

    void Start()
    {
        if (shipPos == null) shipPos = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        BackgroundStarsSparkle();
        BackgroundParallaxAndScroll();
    }

    void BackgroundParallaxAndScroll()
    {
        _scrollYEndPos -= Time.deltaTime;
        if (_scrollYEndPos < -10.0f) _scrollYEndPos = _scrollYStartPos;

        // Scroll parent background
        bgStars1.transform.position = new Vector3(0, _scrollYEndPos, 0);
        bgStars2.transform.position = new Vector3(0, _scrollYEndPos, 0);
        bgStarsEnd1.transform.position = new Vector3(0, _scrollYEndPos + 10.0f, 0);
        bgStarsEnd2.transform.position = new Vector3(0, _scrollYEndPos + 10.0f, 0);

        // Parallax and scroll backgrounds
        bgParallax1.transform.position = new Vector3(shipPos.transform.position.x * -0.01f, _scrollYEndPos, 0);
        bgParallax2.transform.position = new Vector3(shipPos.transform.position.x * -0.04f, _scrollYEndPos, 0);
        bgParallaxEnd1.transform.position = new Vector3(shipPos.transform.position.x * -0.01f, _scrollYEndPos + 10.0f, 0);
        bgParallaxEnd2.transform.position = new Vector3(shipPos.transform.position.x * -0.04f, _scrollYEndPos + 10.0f, 0);
    }

    void BackgroundStarsSparkle()
    {
        _fadeAlpha -= Time.deltaTime;

        bgStars1.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 155));
        bgStars2.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 105));
    }
}
