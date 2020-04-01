using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObstacle : MonoBehaviour
{
    public bool isDestroyable = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Net") && isDestroyable)
        {
            Destroy(this.gameObject);
            Destroy(transform.parent.gameObject); 
        }
        GameController.Score += 100;

        // TODO add obstacle push back function if not destroyable
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Net") && isDestroyable)
        {
            Destroy(this.gameObject);
            Destroy(transform.parent.gameObject);
        }
        GameController.Score += 100;

        // TODO add obstacle push back function if not destroyable
    }
}
