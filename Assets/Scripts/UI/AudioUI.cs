using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    private Slider volume;

    private void Start()
    {
        volume = GetComponent<Slider>();
    }

    public void onMusicChange()
    {
        AudioManager.Instance.SetMusicVolume(volume.value);
        Debug.Log(volume.value);
    }

    public void onSoundFXChange()
    {
        AudioManager.Instance.SetSFXVolume(volume.value);
        Debug.Log(volume.value);
    }
}
