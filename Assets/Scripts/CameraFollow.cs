using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject actor;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - actor.transform.position;
        transform.LookAt(actor.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(actor != null) transform.position = actor.transform.position + offset;
    }
}
