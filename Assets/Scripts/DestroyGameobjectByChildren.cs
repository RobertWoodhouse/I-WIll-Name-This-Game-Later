using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobjectByChildren : MonoBehaviour
{
    public bool hasChildren = true;

    private void LateUpdate() => DestroyObjectByChild(hasChildren);

    void DestroyObjectByChild(bool hasChild) // TODO add to score when destoryed
    {
        if (hasChild == true && transform.childCount == 0)
        {
            Destroy(gameObject);
            //print("Destroy parent");
        }
    }
}
