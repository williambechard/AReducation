using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public static event Action Tick;
    public float tickSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startClock());
    }

    IEnumerator startClock()
    {
        while (true)
        {
            if (!GameManager.Instance.isPaused)Tick?.Invoke();
       
            yield return new WaitForSeconds(tickSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
