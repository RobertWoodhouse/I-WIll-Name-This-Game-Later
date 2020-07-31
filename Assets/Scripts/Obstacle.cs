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

        LevelUpStats();
    }

    private void LateUpdate() => DestroyParentObstacle();

    private void LevelUpStats()
    {
        if (_level == 2) speed = 2.4f;
        if (_level == 3) speed = 2.6f;
        if (_level == 4) speed = 2.8f;
        if (_level == 5) speed = 3.0f;
        if (_level == 6) speed = 3.2f;
        if (_level == 7) speed = 3.4f;
        if (_level == 8) speed = 3.6f;
        if (_level == 9) speed = 3.8f;
        if (_level == 10) speed = 4.0f;
        if (_level == 11) speed = 4.2f;
        if (_level == 12) speed = 4.4f;
        if (_level == 13) speed = 4.6f;
        if (_level == 14) speed = 4.8f;
        if (_level == 15) speed = 5.0f;
        if (_level == 16) speed = 5.2f;
        if (_level == 17) speed = 5.4f;
        if (_level == 18) speed = 5.6f;
        if (_level == 19) speed = 5.8f;
        if (_level == 20) speed = 6.0f;
        if (_level == 21) speed = 6.2f;
        if (_level == 22) speed = 6.4f;
        if (_level == 23) speed = 6.6f;
        if (_level == 24) speed = 6.8f;
        if (_level == 25) speed = 7.0f;
        if (_level == 26) speed = 7.2f;
        if (_level == 27) speed = 7.4f;
        if (_level == 28) speed = 7.6f;
        if (_level == 29) speed = 7.8f;
        if (_level == 30) speed = 8.0f;
        if (_level == 31) speed = 8.2f;
        if (_level == 32) speed = 8.4f;
        if (_level == 33) speed = 8.6f;
        if (_level == 34) speed = 8.8f;
        if (_level == 35) speed = 9.0f;
        if (_level == 36) speed = 9.2f;
        if (_level == 37) speed = 9.4f;
        if (_level == 38) speed = 9.6f;
        if (_level == 39) speed = 9.8f;
        if (_level == 40) speed = 10.0f;
        if (_level == 41) speed = 10.2f;
        if (_level == 42) speed = 10.4f;
        if (_level == 43) speed = 10.6f;
        if (_level >= 44) speed = 10.8f;
    }

    private void DestroyParentObstacle()
    {
        if (countChildren <= 0) Destroy(gameObject);
    }
}
