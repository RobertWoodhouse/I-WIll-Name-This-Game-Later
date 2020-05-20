using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject bgStars1, bgStars2, bgParallax1, bgParallax2, bgStarsEnd1, bgStarsEnd2, bgParallaxEnd1, bgParallaxEnd2, shipPos;

    private float _fadeAlpha = 255, _scrollYStartPos = 0, _scrollYEndPos = 0;
    //private int level;
    private SpriteRenderer _sprite;

    public static float BgScrollSpeed = 1.0f;

    void Start()
    {
        if (shipPos == null) shipPos = GameObject.FindGameObjectWithTag("Player");
        if (_sprite == null) _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //level = GameController.GameLevel;
        ChangeBackgroundColour(GameController.GameLevel);
    }

    void FixedUpdate()
    {
        BackgroundStarsSparkle();
        BackgroundParallaxAndScroll();
    }

    private void BackgroundParallaxAndScroll()
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

    private void BackgroundStarsSparkle()
    {
        _fadeAlpha -= Time.deltaTime;

        bgStars1.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 155));
        bgStars2.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 105));
    }

    private void ChangeBackgroundColour(int level) // Color32(R,G,B,A)
    {
        if (level == 2) _sprite.color = new Color32(191, 255, 255, 255);
        if (level == 3) _sprite.color = new Color32(128, 255, 255, 255);
        if (level == 4) _sprite.color = new Color32(63, 255, 255, 255);
        if (level == 5) _sprite.color = new Color32(0, 255, 255, 255);
        if (level == 6) _sprite.color = new Color32(191, 191, 255, 255);
        if (level == 7) _sprite.color = new Color32(128, 191, 255, 255);
        if (level == 8) _sprite.color = new Color32(63, 191, 255, 255);
        if (level == 9) _sprite.color = new Color32(0, 191, 255, 255);
        if (level == 10) _sprite.color = new Color32(191, 128, 255, 255);
        if (level == 11) _sprite.color = new Color32(128, 128, 255, 255);
        if (level == 12) _sprite.color = new Color32(63, 128, 255, 255);
        if (level == 13) _sprite.color = new Color32(0, 128, 255, 255);
        if (level == 14) _sprite.color = new Color32(191, 63, 255, 255);
        if (level == 15) _sprite.color = new Color32(128, 63, 255, 255);
        if (level == 16) _sprite.color = new Color32(63, 63, 255, 255);
        if (level == 17) _sprite.color = new Color32(0, 63, 255, 255);
        if (level == 18) _sprite.color = new Color32(191, 0, 255, 255);
        if (level == 19) _sprite.color = new Color32(128, 0, 255, 255);
        if (level == 20) _sprite.color = new Color32(63, 0, 255, 255);
        if (level == 20) _sprite.color = new Color32(0, 0, 255, 255);
        if (level == 21) _sprite.color = new Color32(255, 191, 255, 255);
        if (level == 22) _sprite.color = new Color32(255, 128, 255, 255);
        if (level == 23) _sprite.color = new Color32(255, 63, 191, 255);
        if (level == 24) _sprite.color = new Color32(255, 0, 191, 255);
        if (level == 25) _sprite.color = new Color32(255, 191, 128, 255);
        if (level == 26) _sprite.color = new Color32(255, 128, 128, 255);
        if (level == 27) _sprite.color = new Color32(255, 63, 63, 255);
        if (level == 28) _sprite.color = new Color32(255, 0, 63, 255);
        if (level == 29) _sprite.color = new Color32(255, 191, 0, 255);
        if (level == 30) _sprite.color = new Color32(255, 128, 0, 255);
        if (level == 31) _sprite.color = new Color32(255, 63, 0, 255);
        if (level == 32) _sprite.color = new Color32(191, 0, 0, 255);
        if (level == 33) _sprite.color = new Color32(128, 0, 0, 255);
        if (level == 34) _sprite.color = new Color32(63, 0, 0, 255);
        if (level >= 35) _sprite.color = new Color32(0, 0, 0, 255);
    }
}
