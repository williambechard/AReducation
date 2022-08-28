using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WaterCollision : MonoBehaviour
{
    public static event Action onWater;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Collision! " + other.name);
        //add water to plant
        onWater?.Invoke();

        //Destroy Water
        //DestroyObject(other);
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
