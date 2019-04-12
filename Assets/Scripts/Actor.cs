using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Go()
    { 
        if (rb == null) rb = GetComponent<Rigidbody>();
        rb.AddForce(speed, 0, 0, ForceMode.VelocityChange);
    }
}
