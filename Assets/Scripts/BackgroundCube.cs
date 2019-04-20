using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCube : MonoBehaviour
{
    public Transform cube;
    public Transform[] positions;
    public GameObject[] tilePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] tiles = new GameObject[4];

        for(int i = 0; i < tiles.Length; i++)
        {
            GameObject tile = tilePrefabs[Random.Range(0, 9)];
            Instantiate(tile, positions[i].position, positions[i].rotation, cube);
        }
    }

    public bool isVisible()
    {
        return cube.GetComponent<Renderer>().isVisible;
    }
}
