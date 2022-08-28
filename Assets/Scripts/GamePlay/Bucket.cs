using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bucket : MonoBehaviour
{
    public GameObject targetObject;
    public bool isTipped = false;
    public float threshold;
    public ParticleSystem WaterPourEffect;

    float rot;

   

    // Start is called before the first frame update
    void Start()
    {
        WaterPourEffect.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        //true if not spilling
        if (IsUpright())
        {
            if (isTipped)
            {
                isTipped = false;
                //turn off effect
                WaterPourEffect.Stop();
            }
            
        }
        else
        {
            if (!isTipped)
            {
                isTipped = true;
                //turn on effect
                WaterPourEffect.Play();
            }
        }

    }

    public bool IsUpright()
    {
        return targetObject.transform.up.y > threshold;/*say 0.6 ?*/
    }
}
