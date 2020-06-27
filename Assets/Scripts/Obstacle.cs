using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int countChildren = 99; // HACK if set to "<= 0" (in UI) objects won't spawn
    public float speed = 3.0f;
    public SpriteRenderer sprite;

    private int _level = 1;

    private void Awake()
    {
        _level = GameController.GameLevel;
        if (GetComponent<SpriteRenderer>() == null) sprite = GetComponentInChildren<SpriteRenderer>();
        else sprite = GetComponent<SpriteRenderer>();

        //ChangeObstacleColour();
        LevelUpStats();
    }

    private void LateUpdate() => DestroyParentObstacle();
    /*
    private void ChangeObstacleColour() // FIXME change child object colours
    {
        if (_level == 2) sprite.color = new Color32(255, 255, 255, 255);
        if (_level == 3) sprite.color = new Color32(250, 250, 250, 255);
        if (_level == 4) sprite.color = new Color32(245, 245, 245, 255);
        if (_level == 5) sprite.color = new Color32(240, 240, 240, 255);
        if (_level == 6) sprite.color = new Color32(235, 235, 235, 255);
        if (_level == 7) sprite.color = new Color32(230, 230, 230, 255);
        if (_level == 8) sprite.color = new Color32(225, 225, 225, 255);
        if (_level == 10) sprite.color = new Color32(220, 220, 220, 255);
        if (_level == 11) sprite.color = new Color32(215, 215, 215, 255);
        if (_level == 12) sprite.color = new Color32(210, 210, 210, 255);
        if (_level == 13) sprite.color = new Color32(205, 205, 205, 255);
        if (_level == 14) sprite.color = new Color32(200, 200, 200, 255);
        if (_level == 15) sprite.color = new Color32(195, 195, 195, 255);
        if (_level == 16) sprite.color = new Color32(190, 190, 190, 255);
        if (_level == 17) sprite.color = new Color32(185, 185, 185, 255);
        if (_level == 18) sprite.color = new Color32(182, 182, 182, 255);
        if (_level == 19) sprite.color = new Color32(181, 181, 181, 255);
        if (_level == 20) sprite.color = new Color32(180, 180, 180, 255);
        if (_level == 21) sprite.color = new Color32(179, 179, 179, 255);
        if (_level == 22) sprite.color = new Color32(178, 178, 178, 255);
        if (_level == 23) sprite.color = new Color32(177, 177, 177, 255);
        if (_level == 24) sprite.color = new Color32(176, 176, 176, 255);
        if (_level == 25) sprite.color = new Color32(175, 175, 175, 255);
        if (_level == 26) sprite.color = new Color32(174, 174, 174, 255);
        if (_level == 27) sprite.color = new Color32(173, 173, 173, 255);
        if (_level == 28) sprite.color = new Color32(172, 172, 172, 255);
        if (_level == 29) sprite.color = new Color32(171, 171, 171, 255);
        if (_level >= 30) sprite.color = new Color32(170, 170, 170, 255);
    }
    */

    private void LevelUpStats()
    {
        if (_level == 2) speed = 3.2f;
        if (_level == 3) speed = 3.4f;
        if (_level == 4) speed = 3.6f;
        if (_level == 5) speed = 3.8f;
        if (_level == 6) speed = 4.0f;
        if (_level == 7) speed = 4.2f;
        if (_level == 8) speed = 4.4f;
        if (_level == 9) speed = 4.6f;
        if (_level == 10) speed = 4.8f;
        if (_level == 11) speed = 5.0f;
        if (_level == 12) speed = 5.2f;
        if (_level == 13) speed = 5.4f;
        if (_level == 14) speed = 5.6f;
        if (_level == 15) speed = 5.8f;
        if (_level == 16) speed = 6.0f;
        if (_level == 17) speed = 6.2f;
        if (_level == 18) speed = 6.4f;
        if (_level == 19) speed = 6.6f;
        if (_level == 20) speed = 6.8f;
        if (_level == 21) speed = 7.0f;
        if (_level == 22) speed = 7.2f;
        if (_level == 23) speed = 7.4f;
        if (_level == 24) speed = 7.6f;
        if (_level == 25) speed = 7.8f;
        if (_level == 26) speed = 8.0f;
        if (_level == 27) speed = 8.2f;
        if (_level == 28) speed = 8.4f;
        if (_level == 29) speed = 8.6f;
        if (_level == 30) speed = 8.8f;
        if (_level == 31) speed = 9.0f;
        if (_level == 32) speed = 9.2f;
        if (_level == 33) speed = 9.4f;
        if (_level == 34) speed = 9.6f;
        if (_level == 35) speed = 9.8f;
        if (_level == 36) speed = 10.0f;
        if (_level == 37) speed = 10.2f;
        if (_level == 38) speed = 10.4f;
        if (_level == 39) speed = 10.6f;
        if (_level >= 40) speed = 10.8f;
    }

    private void DestroyParentObstacle() // TODO test and remove as may be redundant from destroy by pos
    {
        if (countChildren <= 0) Destroy(gameObject);
    }
}
