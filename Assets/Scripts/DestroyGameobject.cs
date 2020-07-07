using System.Collections;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    public float timer = 4.0f;

    private void Start() => StartCoroutine(DestroyObjectByTime(timer));

    private void LateUpdate() => DestroyObjectByPos();

    IEnumerator DestroyObjectByTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (gameObject.transform.position.y > -8.0f && gameObject.transform.position.y < 8.0f)
        {
            Destroy(gameObject);
        }
        else StartCoroutine(DestroyObjectByTime(10.0f));
    }
    
    void DestroyObjectByPos()
    {
        if (gameObject.transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
