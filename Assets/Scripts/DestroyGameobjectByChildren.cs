using UnityEngine;

public class DestroyGameobjectByChildren : MonoBehaviour
{
    public bool hasChildren = true;

    private void LateUpdate() => DestroyObjectByChild(hasChildren);

    void DestroyObjectByChild(bool hasChild)
    {
        if (hasChild == true && transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
