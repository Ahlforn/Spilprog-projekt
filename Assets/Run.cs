using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

    public float speed = 4f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vi kan benytte en af disse metoder til actor runner
        //den første virker bedst, men det er nok nr.2 der er den rigtige metode at bruge.... 

        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);

        rb.AddForce(0, 0, speed, ForceMode.VelocityChange);

    }
}
