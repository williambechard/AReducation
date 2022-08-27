using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public List<AudioClip> musicClips = new List<AudioClip>();
    public List<AudioClip> sfxClips = new List<AudioClip>();
    public List<AudioClip> backgroundClips = new List<AudioClip>();

    public Dictionary<string, int> musicClipsDict = new Dictionary<string, int>();
    public Dictionary<string, int> sfxClipsDict = new Dictionary<string, int>();
    public Dictionary<string, int> backgroundClipsDict = new Dictionary<string, int>();

    void Setup() {
        musicClipsDict.Add("Menu", 0);
        musicClipsDict.Add("OnShip", 1);
        musicClipsDict.Add("Failure", 3);
        musicClipsDict.Add("OffShip", 4);

        sfxClipsDict.Add("Alarm", 0);
        sfxClipsDict.Add("ComputerSound", 1);
        sfxClipsDict.Add("Explosion", 2);
        sfxClipsDict.Add("Laser1", 3);
        sfxClipsDict.Add("Laser3", 5);
        sfxClipsDict.Add("Laser2", 4);
        sfxClipsDict.Add("Laser4", 6);
        sfxClipsDict.Add("UIHover", 6);
        sfxClipsDict.Add("Walk", 7);
        sfxClipsDict.Add("Walk2", 8);
        sfxClipsDict.Add("DoorOpen", 9);
        sfxClipsDict.Add("DoorClose", 10);
        sfxClipsDict.Add("Interface", 11);
        sfxClipsDict.Add("Blocked", 12);
        sfxClipsDict.Add("Hit", 13);
        sfxClipsDict.Add("ShipExplode", 14);
        sfxClipsDict.Add("Shoot", 15);
        sfxClipsDict.Add("Pickup", 16);
        sfxClipsDict.Add("Wave", 17);
        sfxClipsDict.Add("Roulette", 18);
        sfxClipsDict.Add("Success", 19);
        sfxClipsDict.Add("Fail", 20);
        sfxClipsDict.Add("Locked", 21);

        backgroundClipsDict.Add("ShipNoise", 0);

        Debug.Log("AudioManager Setup" + musicClipsDict["Menu"] + " " + sfxClipsDict);
    }

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource backgroundSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Setup();
        FindObjectOfType<AudioSetup>()?.AudioReady();
    }



    public void PlayMusic(string name)
    {
        if (musicClipsDict.ContainsKey(name))
        {
            this.musicSource.clip = musicClips[musicClipsDict[name]];
            this.musicSource.Play();
        }
    }

    public void PlaySFXOneShot(string name)
    {
        if (sfxClipsDict.ContainsKey(name))
        {
            sfxSource.clip = sfxClips[sfxClipsDict[name]];
            sfxSource.PlayOneShot(sfxSource.clip);
        }
    }

    public void PlaySFX(string name, bool isLooping)
    {
        if (sfxClipsDict.ContainsKey(name))
        {
            sfxSource.clip = sfxClips[sfxClipsDict[name]];
            if (isLooping) sfxSource.loop = true;
            else sfxSource.loop = false;
            sfxSource.Play();
        }
    }

    public void PlayBackground(string name)
    {
        if (backgroundClipsDict.ContainsKey(name))
        {
            backgroundSource.clip = backgroundClips[backgroundClipsDict[name]];
            backgroundSource.Play();
        }
    }

    public void StopBackground()
    {
        backgroundSource.Stop();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void PauseSFX()
    {
        sfxSource.Pause();
    }

    public void UnPauseMusic()
    {
        musicSource.UnPause();
    }

    public void UnPauseSFX()
    {
        sfxSource.UnPause();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void PlaySFXRandomPitch(string name, float minPitch, float maxPitch)
    {
        sfxSource.clip = sfxClips[sfxClipsDict[name]];
        sfxSource.pitch = Random.Range(minPitch, maxPitch);
        sfxSource.Play();
    }
}
