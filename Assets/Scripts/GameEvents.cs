using System;
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

    public event Action<AudioClip, AudioController.SoundEffects> onPlaySFX;
    public void PlaySFX(AudioClip clip, AudioController.SoundEffects sfx) => onPlaySFX?.Invoke(clip, sfx);
}
