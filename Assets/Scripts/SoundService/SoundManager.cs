using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager 
{
    AudioSource SFXsound;
    private SoundTypes[] soundtypes;

    public SoundManager(AudioSource sound, SoundTypes[] soundtypes)
    {
        SFXsound = sound;
        this.soundtypes = soundtypes;
    }

    public void PlaySound(Sound sound)
    {
        AudioClip clip = GetAudioClip(sound);
        if(clip != null)
        {
            SFXsound.PlayOneShot(clip);
        }
    }

    private AudioClip GetAudioClip(Sound sound)
    {
        SoundTypes item=Array.Find(soundtypes,item=>item.Sound==sound);
        if(item != null )
        {
            return item.audioClip;
        }
        return null;
    }
}

[Serializable]
public class SoundTypes
{
    public Sound Sound;
    public AudioClip audioClip;
}

public enum Sound
{
    SPAWNED,
    UNLOCKING_TIMER,
    UNLOCKING_QUEUE,
    UNLOCKED,
    COLLECTED,
    UNDO,
    REJECT
}