using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject bgStars1, bgStars2, bgParallax1, bgParallax2, bgStarsEnd1, bgStarsEnd2, bgParallaxEnd1, bgParallaxEnd2, shipPos;

    private float _fadeAlpha = 255, _scrollYStartPos = 0, _scrollYEndPos = 0;
    private int _level;
    private SpriteRenderer _sprite;

    public static float BgScrollSpeed = 1.0f;

    void Start()
    {
        if (shipPos == null) shipPos = GameObject.FindGameObjectWithTag("Player");
        if (_sprite == null) _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _level = GameController.GameLevel;
        ChangeBackgroundColour();
    }

    void FixedUpdate()
    {
        BackgroundStarsSparkle();
        BackgroundParallaxAndScroll();
    }

    void BackgroundParallaxAndScroll()
    {
        if (shipPos != null)
        {
            _scrollYEndPos -= Time.deltaTime * BgScrollSpeed;
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

            if (BgScrollSpeed >= 10.0f) BgScrollSpeed = 10.0f; // Cap BG scroll speed to 10.0f
        }
    }

    void BackgroundStarsSparkle()
    {
        _fadeAlpha -= Time.deltaTime;

        bgStars1.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 155));
        bgStars2.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 105));
    }

    private void ChangeBackgroundColour() // TODO Fade into colours
    {
        if (_level == 2) _sprite.color = new Color32(114, 238, 114, 255); // GREEN
        if (_level == 3) _sprite.color = new Color32(135, 206, 250, 255); // BLUE
        if (_level == 4) _sprite.color = new Color32(186, 85, 211, 255); // PURPLE
        if (_level >= 5) _sprite.color = new Color32(255, 215, 0, 255); // GOLD
    }
}
