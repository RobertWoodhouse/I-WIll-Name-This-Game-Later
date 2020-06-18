using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProjectile : MonoBehaviour
{
    public int attackPoints = 3;

    private SpriteRenderer _sprite;

    //public AudioClip clipExplosion;

    [SerializeField]
    private float _destroyTime = 0.5f;
    private bool _isCollide = false;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("StarterObstacles"))
        {
            if (!_isCollide) // HACK prevent double collision
            {
                _isCollide = true;
                //GameEvents.S.PlaySFX(clipExplosion, AudioController.SoundEffects.Sound);

                StartCoroutine(DestroyObject(_destroyTime));
                //Destroy(gameObject); // TODO TEST, replace with StartCoroutine above

            }
        }
    }


    IEnumerator DestroyObject(float time) // Destroys object after elapsed time
    {
        //GetComponent<Obstacle>().speed = 1.0f; // Reduce speed of obstacle after explosion
        print("Destroy projectile");

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
        
        //yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
