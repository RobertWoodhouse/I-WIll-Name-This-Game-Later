using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int level = 1, health = 1;
    public float speed = 5.0f;

    private Color colour = new Color32(255, 255, 255, 255); // WHITE
    private SpriteRenderer sprite;

    void Awake()
    {
        level = Random.Range(1, 5); // TEST LEVELS & COLOURS
        sprite = GetComponent<SpriteRenderer>();
        ChangeObstacleColour();
        LevelUpStats();
    }

    private void ChangeObstacleColour()
    {
        if (level == 2) colour = new Color32(114, 238, 114, 255); // GREEN
        if (level == 3) colour = new Color32(135, 206, 250, 255); // BLUE
        if (level == 4) colour = new Color32(186, 85, 211, 255); // PURPLE
        if (level == 5) colour = new Color32(255, 215, 0, 255); // GOLD
        sprite.color = colour;
    }

    private void LevelUpStats()
    {
        if (level == 2)
        {
            health = 2;
            speed = 5.25f;
        }
        if (level == 3)
        {
            health = 3;
            speed = 5.5f;
        }
        if (level == 4)
        {
            health = 4;
            speed = 5.75f;
        }
        if (level == 5)
        {
            health = 5;
            speed = 6.0f;
        }
        if (level == 6)
        {
            health = 6;
            speed = 6.25f;
        }
    }

    public void DamageObstacle(int damage)
    {
        health -= damage;

        if (health <= 0) Destroy(gameObject);
    }
}
