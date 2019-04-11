using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //speed skal sætte så det er det samme som actors speed ellers følges de ikke ad.
    public float cameraSpeed = 4f;
    
   
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos.z += cameraSpeed * Time.deltaTime;

        transform.position = pos;

        
        

        

    }
}
