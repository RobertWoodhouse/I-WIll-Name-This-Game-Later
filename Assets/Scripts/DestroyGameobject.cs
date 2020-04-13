using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    public float timer = 4.0f;

    void Start() => StartCoroutine(DestroyObject(timer));

    IEnumerator DestroyObject(float time) // Destroys object after elapsed time
    {
        // TODO change from elapsed time to screen pos e.g. when y >= -40.0f destroy
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
