using System.Collections;
using UnityEngine;

public class CollisionObstacle : MonoBehaviour
{
    public bool isDestructable = true, isStalled = false;
    public int defencePoints = 3;
    public AudioClip clipCollision;

    [SerializeField]
    private float _destroyTimer = 0.5f;
    private Animator _animObstacle;
    private BoxCollider2D[] _boxColl;
    private SpriteRenderer _sprite;
    private float _tempSpeed;
    [SerializeField]
    private float _kineticSpeedBoost = 2.0f;
    private Obstacle _obstacle;

    private void Start()
    {
        _obstacle = GetComponent<Obstacle>();
        _boxColl = GetComponents<BoxCollider2D>();
        _animObstacle = GetComponent<Animator>();
        _sprite = GetComponent<Obstacle>().sprite;
        if (transform.parent != null) _obstacle.countChildren = transform.parent.gameObject.transform.childCount;
        _tempSpeed = GetComponent<Obstacle>().speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Net"))
        {
            StartCoroutine(DestroyObject(_destroyTimer));
            if (transform.parent != null) _obstacle.countChildren--;
            ScoreController.Score += 100;
        }

        if (collision.CompareTag("Projectile") && isDestructable.Equals(true)) // Destroy destructable objects
        {
            GameEvents.S.PlaySFX(clipCollision, AudioController.SoundEffects.Sound);
            StartCoroutine(DestroyObject(_destroyTimer));
            ScoreController.Score += 300;
        }

        if (collision.CompareTag("Projectile") && isDestructable.Equals(false)) // Push back indestructable objects
        {
            var attackPoints = collision.GetComponent<CollisionProjectile>().attackPoints;
            defencePoints -= attackPoints;
            GameEvents.S.PlaySFX(clipCollision, AudioController.SoundEffects.Sound);
            if (defencePoints <= 0)
            {
                print("Destroy metal obeject");
                StartCoroutine(DestroyObject(_destroyTimer));
                ScoreController.Score += 600;
            }
            StartCoroutine("KineticCharge");
        }
    }

    IEnumerator KineticCharge()
    {
        if (!isStalled)
        {
            isStalled = true;
            _obstacle.speed = 0f;
            _obstacle.sprite.color = Color.grey;
            yield return new WaitForSeconds(1.0f);
            _obstacle.sprite.color = SetObstacleColour();
            _obstacle.speed = _tempSpeed += _kineticSpeedBoost;
            isStalled = false;
        }
    }

    private Color SetObstacleColour()
    {
        Color colour = new Color32(255, 255, 255, 255);
        if (defencePoints == 2) colour = new Color32(255, 128, 128, 255);
        if (defencePoints <= 1) colour = new Color32(255, 64, 64, 255);
        return colour;
    }
    
    IEnumerator DestroyObject(float time) // Destroys object after elapsed time
    {
        GetComponent<Obstacle>().speed = 1.0f; // Reduce speed of obstacle after explosion
        foreach(BoxCollider2D coll in _boxColl) coll.enabled = false; // Disable all attached colliders to prevent collisions during explosion animation
        if (_animObstacle != null) // Explode animation
        {
            _animObstacle.SetTrigger("ObstacleExplode");
            yield return new WaitForSeconds(time);
        }
        else // Shrink and fade animation
        {
            _sprite.color = new Color32(255, 255, 255, 205);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
            yield return new WaitForSeconds(0.1f);
            _sprite.color = new Color32(255, 255, 255, 155);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
            yield return new WaitForSeconds(0.1f);
            _sprite.color = new Color32(255, 255, 255, 105);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
            yield return new WaitForSeconds(0.1f);
            _sprite.color = new Color32(255, 255, 255, 55);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
            yield return new WaitForSeconds(0.1f);
            _sprite.color = new Color32(255, 255, 255, 5);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
        }
        Destroy(gameObject);
    }
}
