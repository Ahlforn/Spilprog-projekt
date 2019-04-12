using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float timeCount = 0.0f;
    public Transform from;
    public Transform to;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(from != null && to != null)
        {
            transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
            timeCount = timeCount + Time.deltaTime;

            if (Mathf.Abs(transform.rotation.x).Equals(to.rotation.x))
            {
                from = null;
                to = null;
                timeCount = 0.0f;
            }
        }
    }
}
