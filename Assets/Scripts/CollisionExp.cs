﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExp : MonoBehaviour
{
    public AudioClip clipSpeedUpUK, clipSpeedUpUS, clipSpeedUpJA, clipPowerUpUK, clipPowerUpUS, clipPowerUpJA;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (gameObject.CompareTag("ExpSpeed") || gameObject.CompareTag("StarterExpSpeed")))
        {
            Exp.S.SpeedUp();
            ScoreController.Score += 500;
            if (collision.name == "Ship_UK") GameEvents.S.PlaySFX(clipSpeedUpUK, AudioController.SoundEffects.Voice);
            if (collision.name == "Ship_US") GameEvents.S.PlaySFX(clipSpeedUpUS, AudioController.SoundEffects.Voice);
            if (collision.name == "Ship_JA") GameEvents.S.PlaySFX(clipSpeedUpJA, AudioController.SoundEffects.Voice);
            print("Speed Up");
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player") && (gameObject.CompareTag("ExpPower") || gameObject.CompareTag("StarterExpPower")))
        {
            Exp.S.PowerUp();
            ScoreController.Score += 500;
            if (collision.name == "Ship_UK") GameEvents.S.PlaySFX(clipPowerUpUK, AudioController.SoundEffects.Voice);
            if (collision.name == "Ship_US") GameEvents.S.PlaySFX(clipPowerUpUS, AudioController.SoundEffects.Voice);
            if (collision.name == "Ship_JA") GameEvents.S.PlaySFX(clipPowerUpJA, AudioController.SoundEffects.Voice);
            print("Power Up");
            Destroy(gameObject);
        }
    }
}
