using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObstacle : MonoBehaviour
{
    public bool isDestructable = true, isInvincible = false;
    public int health = 2;
    public AudioClip clipCollision;

    [SerializeField]
    private float _destroyTimer = 0.5f;
    private Animator _animObstacle;
    private BoxCollider2D[] _boxColl;
    private SpriteRenderer _sprite;
    //private Obstacle _obstacle;

    private void Start()
    {
        _boxColl = GetComponents<BoxCollider2D>();
        _animObstacle = GetComponent<Animator>();
        _sprite = GetComponent<Obstacle>().sprite;
        //_obstacle = GetComponent<Obstacle>();
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
            if (!isInvincible)
            {
                if(health <= 0)
                {
                    print("Destroy metal obeject");
                    StartCoroutine(DestroyObject(_destroyTimer));
                    ScoreController.Score += 600;
                }
                health--;
            }
            //StartCoroutine(DestroyObject(_destroyTimer)); // TEST
            StartCoroutine("KineticCharge");
        }
    }

    IEnumerator KineticCharge()
    {
        isInvincible = true;
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
        isInvincible = false;
    }
    
    IEnumerator DestroyObject(float time) // Destroys object after elapsed time
    {
        //print("Destroy obstacle and animate explosion");
        GetComponent<Obstacle>().speed = 1.0f; // Reduce speed of obstacle after explosion
        //_animObstacle.SetTrigger("ObstacleExplode");
        foreach(BoxCollider2D coll in _boxColl) coll.enabled = false; // Disable all attached colliders to prevent collisions during explosion animation
        if (_animObstacle != null) // Explode animation
        {
            _animObstacle.SetTrigger("ObstacleExplode");
            yield return new WaitForSeconds(time);
        }
        else // Shrink and fade animation
        {
            /*
            GetComponent<Obstacle>().sprite.color = new Color32(255, 255, 255, 205);
            GetComponent<Obstacle>().transform.localScale = new Vector3(0.50f, 0.50f, 1.0f);
            yield return new WaitForSeconds(0.25f);
            GetComponent<Obstacle>().sprite.color = new Color32(255, 255, 255, 155);
            GetComponent<Obstacle>().transform.localScale = new Vector3(0.25f, 0.25f, 1.0f);
            yield return new WaitForSeconds(0.25f);
            GetComponent<Obstacle>().sprite.color = new Color32(255, 255, 255, 105);
            GetComponent<Obstacle>().transform.localScale = new Vector3(0.125f, 0.125f, 1.0f);
            yield return new WaitForSeconds(0.25f);
            GetComponent<Obstacle>().sprite.color = new Color32(255, 255, 255, 55);
            GetComponent<Obstacle>().transform.localScale = new Vector3(0.125f, 0.125f, 1.0f);
            yield return new WaitForSeconds(0.25f);
            GetComponent<Obstacle>().sprite.color = new Color32(255, 255, 255, 5);
            GetComponent<Obstacle>().transform.localScale = new Vector3(0.0625f, 0.0625f, 1.0f);
            */

            _sprite.color = new Color32(255, 255, 255, 205);
            //transform.localScale = new Vector3(0.50f, 0.50f, 1.0f);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
            yield return new WaitForSeconds(0.2f);
            _sprite.color = new Color32(255, 255, 255, 155);
            //transform.localScale = new Vector3(0.25f, 0.25f, 1.0f);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
            yield return new WaitForSeconds(0.2f);
            _sprite.color = new Color32(255, 255, 255, 105);
            //transform.localScale = new Vector3(0.125f, 0.125f, 1.0f);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
            yield return new WaitForSeconds(0.2f);
            _sprite.color = new Color32(255, 255, 255, 55);
            //transform.localScale = new Vector3(0.125f, 0.125f, 1.0f);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
            yield return new WaitForSeconds(0.2f);
            _sprite.color = new Color32(255, 255, 255, 5);
            //transform.localScale = new Vector3(0.0625f, 0.0625f, 1.0f);
            transform.localScale = new Vector3((transform.localScale.x * 0.75f), (transform.localScale.y * 0.75f), 1.0f);
        }
        //yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
