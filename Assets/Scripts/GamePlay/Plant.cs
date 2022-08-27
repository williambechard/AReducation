using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plant : MonoBehaviour
{

    //idea if we can detect light level, and option might be
    // turning off light then turning it on forces a 24 time
    // which is a growTickTarget

    public float waterLevel;
    public float sunLevel;
    public float nutrientLevel;

    public float targetNutrientLevel = 100;

    public static event Action onGrow;
    public static event Action onWilt;
    public static event Action onBurn;

    public float growTick = 0;
    public float growTickTarget;

    // Start is called before the first frame update
    void Start()
    {
        Clock.Tick += Tick;
    }

    void Tick()
    {
        if (growTick >= growTickTarget)
        {
            growTick = 0; //reset our timer for our growth
            //check if our nutrient level is good
            if (nutrientLevel >= targetNutrientLevel)
            {
                onGrow?.Invoke();
            }

        }
        else growTick++;
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
