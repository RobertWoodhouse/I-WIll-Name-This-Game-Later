using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    private Animator animShip;

    private void Start()
    {
        animShip = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle")) StartCoroutine(DestroyObject(0.7f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) StartCoroutine(DestroyObject(0.7f));
    }

    IEnumerator DestroyObject(float time) // Destroys object after elapsed time
    {
        print("Destroy player and animate explosion");
        animShip.SetTrigger("ShipExplode");
        Destroy(gameObject.transform.GetChild(0).gameObject); // HACK destroy Afterburner child GO to stop animator 
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
