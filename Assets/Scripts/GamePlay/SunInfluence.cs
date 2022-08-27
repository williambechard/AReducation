using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunInfluence : MonoBehaviour
{

     

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sun Entered " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Sun Exit4 " + other.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
