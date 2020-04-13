using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExp : MonoBehaviour
{
    public AudioClip clipExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.CompareTag("ExpSpeed"))
        {
            Exp.S.SpeedUp();
            GameEvents.S.PlaySFX(clipExplosion);
            print("Speed Up");
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player") && gameObject.CompareTag("ExpPower"))
        {
            Exp.S.PowerUp();
            GameEvents.S.PlaySFX(clipExplosion);
            print("Power Up");
            Destroy(gameObject);
        }
    }
}
