using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProjectile : MonoBehaviour
{
    public int attackPoints = 3;

    [SerializeField]
    private bool _isAnimated = false;
    private SpriteRenderer _sprite;

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

                if (_isAnimated) StartCoroutine(DestroyObject(_destroyTime));
                else Destroy(gameObject); // TODO TEST, replace with StartCoroutine above
            }
        }
    }


    IEnumerator DestroyObject(float time) // Destroys object after elapsed time
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; // Reduce speed of projectile after collision
        print("Destroy projectile");

        _sprite.color = new Color32(255, 255, 255, 205);
        //transform.localScale = new Vector3(1.0f, (transform.localScale.y * 0.50f), 1.0f);
        yield return new WaitForSeconds(0.0125f);
        _sprite.color = new Color32(255, 255, 255, 105);
        //transform.localScale = new Vector3(1.0f, (transform.localScale.y * 0.50f), 1.0f);
        yield return new WaitForSeconds(0.125f);
        _sprite.color = new Color32(255, 255, 255, 55);
        //transform.localScale = new Vector3(1.0f, (transform.localScale.y * 0.50f), 1.0f);
        yield return new WaitForSeconds(0.0125f);
        _sprite.color = new Color32(255, 255, 255, 5);
        //transform.localScale = new Vector3(1.0f, (transform.localScale.y * 0.50f), 1.0f);
        yield return new WaitForSeconds(0.0125f);
        _sprite.color = new Color32(255, 255, 255, 0);
        //transform.localScale = new Vector3(1.0f, (transform.localScale.y * 0.50f), 1.0f);

        //yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
