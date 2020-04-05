using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObstacle : MonoBehaviour
{
    public bool isDestructable = true;

    [SerializeField]
    private float _destroyTimer = 0.5f;
    private Animator _animObstacle;
    private BoxCollider2D[] _boxColl;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxColl = GetComponents<BoxCollider2D>();
        _animObstacle = GetComponent<Animator>();
        if (transform.parent != null) GetComponentInParent<Obstacle>().countChildren = transform.parent.gameObject.transform.childCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Net"))
        {
            print("In the net!");
            StartCoroutine(DestroyObject(_destroyTimer));
            GetComponentInParent<Obstacle>().countChildren--;
            GameController.Score += 100;
        }

        if (collision.CompareTag("Projectile") && isDestructable.Equals(true))
        {
            print("DETROYED!");
            Destroy(collision.gameObject);
            StartCoroutine(DestroyObject(_destroyTimer));
            GameController.Score += 300;
        }

        if (collision.CompareTag("Projectile") && isDestructable.Equals(false)) // Push back indestructable objects
        {
            print("Push BACK!!");
            Destroy(collision.gameObject);
            _rb.AddForce(transform.up * 20f);
        }
    }

    IEnumerator DestroyObject(float time) // Destroys object after elapsed time
    {
        print("Destroy obstacle and animate explosion");
        this.GetComponent<Obstacle>().speed = 1.0f; // Reduce speed of obstacle after explosion
        _animObstacle.SetTrigger("ObstacleExplode");
        foreach(BoxCollider2D coll in _boxColl) // Disable all attached colliders
        {
            coll.enabled = false;
        }
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
