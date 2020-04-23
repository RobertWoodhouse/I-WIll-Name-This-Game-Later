using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _intruments;

    public AudioClip[] Instruments
    {
        get { return _intruments; }
        set { _intruments = value; }
    }

    [SerializeField]
    private bool[] _channels;

    private AudioSource _source;

    public AudioSource Source // = GameController
    {
        get { return _source; }
        set { _source = value; }
    }

    private AudioSource[] audioSources; // = GetComponents<AudioSource>();

    //public AudioClip sfxClipSwoosh, sfxClipExplosion;
    private AudioSource audioSrcSfx;

    public static AudioController S;

    public void Start()
    {
        //audioSources = GetComponents<AudioSource>();
        audioSrcSfx = GetComponent<AudioSource>(); // FIXME SFX pauses audio, check source component
        //GameEvents.S.onPlayAudio += PlayBackgroundMusicTracks;
        //GameEvents.S.PlayAudio(Instruments, Source);
        GameEvents.S.onPlaySFX += PlaySFX;
        PlayBGMTracks(Instruments, Source);
        S = this;
    }

    private void Update()
    {
        //MuteAudioTracks(_channels);
        //IntrumentsSwitch(Scales.LevelOfScales);
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
    }

    private void IntrumentsSwitch(int scaleLevel) // TODO: change from >= to == if switch not functioning
    {
        if (scaleLevel >= 1) _channels[0] = true;
        else _channels[0] = false;

        if (scaleLevel >= 2) _channels[1] = true;
        else _channels[1] = false;

        if (scaleLevel >= 3) _channels[2] = true;
        else _channels[2] = false;

        if (scaleLevel >= 4) _channels[3] = true;
        else _channels[3] = false;

        if (scaleLevel >= 5) _channels[4] = true;
        else _channels[4] = false;

        if (scaleLevel >= 6) _channels[5] = true;
        else _channels[5] = false;
    }

    public void PlayBGMTracks(AudioClip[] clip, AudioSource source)
    {
        for (int i = 0; i < clip.Length; i++)
        {
            audioSources[i].loop = true;
            audioSources[i].clip = clip[i];
            audioSources[i].Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        print("Play Sound Effect");
        audioSrcSfx.loop = false;
        audioSrcSfx.clip = clip;
        audioSrcSfx.Play();
    }
}
