using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    public float timer = 4.0f;

    private void Start() => StartCoroutine(DestroyObjectByTime(timer));

    private void LateUpdate() => DestroyObjectByPos();

    IEnumerator DestroyObjectByTime(float time) // TODO test and remove as it is redundant
    {
        yield return new WaitForSeconds(time);
        if (gameObject.transform.position.y > -8.0f && gameObject.transform.position.y < 8.0f)
        {
            Destroy(gameObject);
            //print("Destroy by time and space");
        }
        else StartCoroutine(DestroyObjectByTime(10.0f));
    }
    
    void DestroyObjectByPos() // TODO add to score when destoryed
    {
        if (gameObject.transform.position.y < -10.0f)
        {
            Destroy(gameObject);
            //print("Object out of bounds");
        }
    }
}
