using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int level = 1, health = 1, countChildren = 99; // HACK if set to "<= 0" (in UI) objects won't spawn
    public float speed = 5.0f;
    public float[] spawnXPosRange = new[] { -1.94f, -1.212f, -0.484f, 0.244f, 0.972f };
    private Color colour = new Color32(255, 255, 255, 255); // WHITE
    private SpriteRenderer sprite;

    void Awake()
    {
        //level = Random.Range(1, 5); // TEST LEVELS & COLOURS
        level = GameController.GameLevel;
        if (GetComponent<SpriteRenderer>() == null) sprite = GetComponentInChildren<SpriteRenderer>();
        else sprite = GetComponent<SpriteRenderer>();

        //spawnXPosRange = new[] { -1.94f, -1.212f, -0.484f, 0.244f, 0.972f }; // HACK Default spawn range, set unique ranges in inspector for each obstacle

        ChangeObstacleColour();
        LevelUpStats();
    }

    private void Update()
    {
        DestroyParentObstacle();
    }

    private void ChangeObstacleColour() // TODO change child object colours
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
