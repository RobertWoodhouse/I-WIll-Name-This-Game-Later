using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObstacle : MonoBehaviour
{
    public bool isDestroyable = true;

    //[SerializeField]
    //private int countChildren = 99;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.parent != null) GetComponentInParent<Obstacle>().countChildren = transform.parent.gameObject.transform.childCount;//transform.childCount;
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Net"))
        {
            print("In the net!");
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
            GameController.Score += 100;
        }

        if (collision.collider.CompareTag("Projectile") && isDestroyable.Equals(true))
        {
            print("DETROYED!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
            GameController.Score += 300;
        }

        if (collision.collider.CompareTag("Projectile") && isDestroyable.Equals(false)) // TODO add obstacle push back function if not destroyable
        {
            print("Push BACK!!");
            Destroy(collision.gameObject);
            rb.AddForce(transform.up * 20f);
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Net"))
        {
            print("In the net!");
            Destroy(gameObject);
            //if (transform.parent != null) Destroy(transform.parent.gameObject);
            GetComponentInParent<Obstacle>().countChildren--;
            GameController.Score += 100;
        }

        if (collision.CompareTag("Projectile") && isDestroyable.Equals(true))
        {
            print("DETROYED!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //if (transform.parent != null)  Destroy(transform.parent.gameObject);
            GameController.Score += 300;
        }

        if (collision.CompareTag("Projectile") && isDestroyable.Equals(false)) // TODO add obstacle push back function if not destroyable
        {
            print("Push BACK!!");
            Destroy(collision.gameObject);
            rb.AddForce(transform.up * 20f);
        }
    }
}
