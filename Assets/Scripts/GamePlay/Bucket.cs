using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public GameObject targetObject;
    public bool isTipped = false;
    public float threshold;
    float rot;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        rot = Quaternion.Angle(targetObject.transform.rotation, Quaternion.identity);
        Debug.Log(rot);
      
        if ((rot > 45f))
        {
            isTipped = true;
        }
        else
        {
            isTipped = false;
        }
        */
        Debug.Log(IsUpright());

    }

    public bool IsUpright()
    {
        return targetObject.transform.up.y > threshold;/*say 0.6 ?*/
    }
}
