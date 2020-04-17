using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    public float timer = 4.0f;

    private void Start() => StartCoroutine(DestroyObjectByTime(timer));

    private void Update() => DestroyObjectByPos();

    IEnumerator DestroyObjectByTime(float time) // TODO test and remove as it is redundant
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    void DestroyObjectByPos() // TODO add to score when destoryed
    {
        if (gameObject.transform.localPosition.y < -10.0f)
        {
            Destroy(gameObject);
            print("Object out of bounds");
        }
    }
}
