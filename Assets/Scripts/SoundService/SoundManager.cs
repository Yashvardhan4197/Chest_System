using System;
using UnityEngine;

public class SoundManager 
{
    private AudioSource SFXsound;
    private SoundTypes[] soundtypes;

    private AudioClip GetAudioClip(Sound sound)
    {
        SoundTypes item = Array.Find(soundtypes, item => item.Sound == sound);
        if (item != null)
        {
            return item.audioClip;
        }
        return null;
    }
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