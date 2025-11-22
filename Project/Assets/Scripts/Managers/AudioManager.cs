using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AudioSources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("SoundData")]
    public SoundData[] sounds;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        SoundData s = Array.Find(sounds, sound => sound.name == name);

        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.volume= s.volume;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        SoundData s = Array.Find(sounds, sound => sound.name == name);

        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip, s.volume);
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}

[System.Serializable]
public class SoundData
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;
}