using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GoalEntered();
    }
}
