﻿using UnityEngine;

public class AudioController : MonoBehaviour
{
    public enum SoundEffects
    {
        Voice,
        Sound,
        Menu
    }

    [SerializeField]
    private AudioClip[] _intruments;

    public AudioClip[] Instruments
    {
        get { return _intruments; }
        set { _intruments = value; }
    }

    [SerializeField]
    private bool[] _channels;
    private AudioSource[] audioSources;
    private AudioSource[] audioSrcsSfx = new AudioSource[3];

    public static AudioController S;

    public void Start()
    {
        S = this;
        _channels = new bool[Instruments.Length];
        audioSources = GetComponents<AudioSource>();
        audioSrcsSfx[0] = GetComponents<AudioSource>()[7];
        audioSrcsSfx[1] = GetComponents<AudioSource>()[8];
        audioSrcsSfx[2] = GetComponents<AudioSource>()[9];
        GameEvents.S.onPlaySFX += PlaySFX;
        PlayBGMTracks(Instruments);
    }

    private void Update()
    {
        MuteAudioTracks(_channels);
        IntrumentsSwitch(GameController.GameLevel);
    }

    private void MuteAudioTracks(bool[] channel)
    {
        if (!channel[0]) audioSources[0].mute = true;
        else audioSources[0].mute = false;

        if (!channel[1]) audioSources[1].mute = true;
        else audioSources[1].mute = false;

        if (!channel[2]) audioSources[2].mute = true;
        else audioSources[2].mute = false;

        if (!channel[3]) audioSources[3].mute = true;
        else audioSources[3].mute = false;

        if (!channel[4]) audioSources[4].mute = true;
        else audioSources[4].mute = false;

        if (!channel[5]) audioSources[5].mute = true;
        else audioSources[5].mute = false;

        if (!channel[6]) audioSources[6].mute = true;
        else audioSources[6].mute = false;
    }

    private void IntrumentsSwitch(int scaleLevel)
    {
        if (scaleLevel >= 1) _channels[0] = true;
        else _channels[0] = false;

        if (scaleLevel >= 2) _channels[1] = true;
        else _channels[1] = false;

        if (scaleLevel >= 5) _channels[2] = true;
        else _channels[2] = false;

        if (scaleLevel >= 7) _channels[3] = true;
        else _channels[3] = false;

        if (scaleLevel >= 10) _channels[4] = true;
        else _channels[4] = false;

        if (scaleLevel >= 14) _channels[5] = true;
        else _channels[5] = false;

        if (scaleLevel >= 20) _channels[6] = true;
        else _channels[6] = false;
    }

    public void PlayBGMTracks(AudioClip[] clip)
    {
        for (int i = 0; i < clip.Length; i++)
        {
            audioSources[i].loop = true;
            audioSources[i].clip = clip[i];
            audioSources[i].Play();
        }
    }

    public void PlaySFX(AudioClip clip, SoundEffects sfx)
    {
        if (sfx == SoundEffects.Sound)
        {
            audioSrcsSfx[0].loop = false;
            audioSrcsSfx[0].clip = clip;
            audioSrcsSfx[0].Play();
        }
        if (sfx == SoundEffects.Voice)
        {
            audioSrcsSfx[1].loop = false;
            audioSrcsSfx[1].clip = clip;
            audioSrcsSfx[1].Play();
        }
        if (sfx == SoundEffects.Menu)
        {
            audioSrcsSfx[2].loop = false;
            audioSrcsSfx[2].clip = clip;
            audioSrcsSfx[2].Play();
        }
    }
}
