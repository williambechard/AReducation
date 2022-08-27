using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClockAware : MonoBehaviour
{

    public float TickValue;

    // Start is called before the first frame update
    void Start()
    {
        Clock.Tick +=Tick;
    }

    void Tick()
    {

    }

    private void OnDisable()
    {
        Clock.Tick -= Tick;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
