using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExp : MonoBehaviour
{
    public AudioClip clipSpeedUpUK, clipSpeedUpUS, clipSpeedUpJA, clipPowerUpUK, clipPowerUpUS, clipPowerUpJA;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.CompareTag("ExpSpeed"))
        {
            Exp.S.SpeedUp();
            if (collision.name == "Ship_UK") GameEvents.S.PlaySFX(clipSpeedUpUK);
            if (collision.name == "Ship_US") GameEvents.S.PlaySFX(clipSpeedUpUS);
            if (collision.name == "Ship_JA") GameEvents.S.PlaySFX(clipSpeedUpJA);
            print("Speed Up");
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player") && gameObject.CompareTag("ExpPower"))
        {
            Exp.S.PowerUp();
            if (collision.name == "Ship_UK") GameEvents.S.PlaySFX(clipPowerUpUK);
            if (collision.name == "Ship_US") GameEvents.S.PlaySFX(clipPowerUpUS);
            if (collision.name == "Ship_JA") GameEvents.S.PlaySFX(clipPowerUpJA);
            print("Power Up");
            Destroy(gameObject);
        }
    }
}
