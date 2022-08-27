using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetup : MonoBehaviour
{
    //get the audio manager scene
    public string musicName;
    public string backgroundSFXName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForAudio());
    }

    IEnumerator waitForAudio()
    {
        while (AudioManager.Instance == null)
        {
            yield return new WaitForEndOfFrame();
        }

        AudioReady();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioReady()
    {
        if (musicName != "")
        {
            Debug.Log("Music Name = " + musicName);
            AudioManager.Instance.PlayMusic(musicName);
        }
        else
        {
            Debug.Log("Music name is empty");
            AudioManager.Instance.StopMusic();
        }

        if (backgroundSFXName != "") AudioManager.Instance.PlayBackground(backgroundSFXName);
        else AudioManager.Instance.StopBackground();
    }
}
