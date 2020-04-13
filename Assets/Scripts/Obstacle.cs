using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int health = 1, countChildren = 99; // HACK if set to "<= 0" (in UI) objects won't spawn
    public float speed = 5.0f;
    public float[] spawnXPosRange = new[] { -1.94f, -1.212f, -0.484f, 0.244f, 0.972f };

    private SpriteRenderer _sprite;
    private int _level = 1;

    void Awake()
    {
        _level = GameController.GameLevel;
        if (GetComponent<SpriteRenderer>() == null) _sprite = GetComponentInChildren<SpriteRenderer>();
        else _sprite = GetComponent<SpriteRenderer>();

        ChangeObstacleColour();
        LevelUpStats();
    }

    private void LateUpdate() => DestroyParentObstacle();


    private void ChangeObstacleColour() // FIXME change child object colours
    {
        if (_level == 2) _sprite.color = new Color32(114, 238, 114, 255); // GREEN
        if (_level == 3) _sprite.color = new Color32(135, 206, 250, 255); // BLUE
        if (_level == 4) _sprite.color = new Color32(186, 85, 211, 255); // PURPLE
        if (_level >= 5) _sprite.color = new Color32(255, 215, 0, 255); // GOLD
    }

    private void LevelUpStats()
    {
        if (_level == 2)
        {
            health = 2;
            speed = 4.25f;
        }
        if (_level == 3)
        {
            health = 3;
            speed = 4.5f;
        }
        if (_level == 4)
        {
            health = 4;
            speed = 4.75f;
        }
        if (_level == 5)
        {
            health = 5;
            speed = 5.0f;
        }
        if (_level >= 6)
        {
            health = 6; 
            speed = 5.25f;
        }
    }

    public void DamageObstacle(int damage) // TODO Finish obstacle damange
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }

    private void DestroyParentObstacle()
    {
        if (countChildren <= 0) Destroy(gameObject);
    }
}
