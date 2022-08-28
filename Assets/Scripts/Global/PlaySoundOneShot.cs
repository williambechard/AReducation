using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOneShot : MonoBehaviour
{
    public string SoundFXName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playSound()
    {
        StartCoroutine(waitForAudio());
    }

    IEnumerator waitForAudio()
    {
        while (AudioManager.Instance == null)
        {
            yield return new WaitForEndOfFrame();
        }
        AudioManager.Instance.PlaySFXOneShot(SoundFXName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
