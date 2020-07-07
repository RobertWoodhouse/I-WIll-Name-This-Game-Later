using System.Collections;
using UnityEngine;

public class CollisionProjectile : MonoBehaviour
{
    public int attackPoints = 3;

    [SerializeField]
    private bool _isAnimated = false;
    private SpriteRenderer _sprite;
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
                if (_isAnimated) StartCoroutine(DestroyObject());
                else Destroy(gameObject);
            }
        }
    }


    IEnumerator DestroyObject() // Destroys object after elapsed time
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; // Reduce speed of projectile after collision
        print("Destroy projectile");

        _sprite.color = new Color32(255, 255, 255, 205);
        yield return new WaitForSeconds(0.0125f);
        _sprite.color = new Color32(255, 255, 255, 105);
        yield return new WaitForSeconds(0.125f);
        _sprite.color = new Color32(255, 255, 255, 55);
        yield return new WaitForSeconds(0.0125f);
        _sprite.color = new Color32(255, 255, 255, 5);
        yield return new WaitForSeconds(0.0125f);
        _sprite.color = new Color32(255, 255, 255, 0);

        Destroy(gameObject);
    }
}
