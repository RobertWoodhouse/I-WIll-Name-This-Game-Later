using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObstacle : MonoBehaviour
{
    public bool isDestructable = true;
    public AudioClip clipCollision;

    [SerializeField]
    private float _destroyTimer = 0.5f;
    private Animator _animObstacle;
    private BoxCollider2D[] _boxColl;

    private void Start()
    {
        _boxColl = GetComponents<BoxCollider2D>();
        _animObstacle = GetComponent<Animator>();
        if (transform.parent != null) GetComponentInParent<Obstacle>().countChildren = transform.parent.gameObject.transform.childCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Net"))
        {
            StartCoroutine(DestroyObject(_destroyTimer));
            if (transform.parent != null) GetComponentInParent<Obstacle>().countChildren--; // TODO TEST IF STATEMENT IS WORKING
            ScoreController.Score += 100;
        }

        if (collision.CompareTag("Projectile") && isDestructable.Equals(true)) // Destroy destructable objects
        {
            GameEvents.S.PlaySFX(clipCollision, AudioController.SoundEffects.Sound);
            Destroy(collision.gameObject);
            StartCoroutine(DestroyObject(_destroyTimer));
            ScoreController.Score += 300;
        }

        if (collision.CompareTag("Projectile") && isDestructable.Equals(false)) // Push back indestructable objects
        {
            GameEvents.S.PlaySFX(clipCollision, AudioController.SoundEffects.Sound);
            Destroy(collision.gameObject);
            StartCoroutine("KineticCharge");
            //ScoreController.Score += 20; // FIXME may work as score boost cheat
        }
    }

    IEnumerator KineticCharge()
    {
        var tempSpeed = GetComponent<Obstacle>().speed;
        var tempColour = GetComponent<Obstacle>().sprite.color;
        GetComponent<Obstacle>().speed = 0f;
        GetComponent<Obstacle>().sprite.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Obstacle>().sprite.color = tempColour;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Obstacle>().sprite.color = Color.red;
        yield return new WaitForSeconds(0.33f);
        GetComponent<Obstacle>().sprite.color = tempColour;
        yield return new WaitForSeconds(0.33f);
        GetComponent<Obstacle>().sprite.color = Color.red;
        yield return new WaitForSeconds(0.33f);
        GetComponent<Obstacle>().sprite.color = tempColour;
        yield return new WaitForSeconds(0.25f);
        GetComponent<Obstacle>().sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        GetComponent<Obstacle>().sprite.color = tempColour;
        yield return new WaitForSeconds(0.25f);
        GetComponent<Obstacle>().sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        GetComponent<Obstacle>().sprite.color = tempColour;
        GetComponent<Obstacle>().speed = tempSpeed+=0.25f;
    }
    
    IEnumerator DestroyObject(float time) // Destroys object after elapsed time
    {
        print("Destroy obstacle and animate explosion");
        GetComponent<Obstacle>().speed = 1.0f; // Reduce speed of obstacle after explosion
        _animObstacle.SetTrigger("ObstacleExplode");
        foreach(BoxCollider2D coll in _boxColl) coll.enabled = false; // Disable all attached colliders to prevent collisions during explosion animation
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
