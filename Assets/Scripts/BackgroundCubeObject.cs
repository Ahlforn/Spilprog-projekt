using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCubeObject : MonoBehaviour
{
    public delegate void OnExitFromView(GameObject obj);
    public static OnExitFromView exitFromView;

    private void OnBecameInvisible()
    {
        exitFromView(gameObject);
    }
}
