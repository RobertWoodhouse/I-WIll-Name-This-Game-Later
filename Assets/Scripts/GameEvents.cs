using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents S;

    private void Awake()
    {
        S = this;
    }

    public event Action<int, string> onTouchpadDown;
    public void TouchpadDown(int id, string direction)
    {
        if (onTouchpadDown != null) onTouchpadDown(id, direction);
    }

    public event Action<AudioClip> onPlaySFX; // TODO Change method to include AudioSource from GO instead of AudioController GO
    public void PlaySFX(AudioClip clip) => onPlaySFX?.Invoke(clip);
}
