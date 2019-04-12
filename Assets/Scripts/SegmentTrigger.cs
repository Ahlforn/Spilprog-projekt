using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentTrigger : MonoBehaviour
{
    private SegmentControler controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = transform.parent.GetComponent<SegmentControler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        controller.ActorEntered();
    }
}
