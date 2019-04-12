using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentControler : MonoBehaviour
{
    public Transform rotator;
    public Transform cube;
    public Transform[] positions;
    public Transform[] tiles;
    public Material cubeIdle;
    public Material cubeSelected;
    public Material cubeRotating;
    public bool active = false;
    public bool actorEntered = false;
    int currentPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(Transform tile in this.tiles)
        {
            tile.SetPositionAndRotation(positions[i].position, positions[i].rotation);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetButtonDown("Rotate") && rotator.GetComponent<Rotate>().to == null)
        {
            currentPosition += (Input.GetAxis("Rotate") > 0) ? 1 : -1;

            if (currentPosition < 0) currentPosition = positions.Length - 1;
            else if (currentPosition > positions.Length - 1) currentPosition = 0;

            rotator.GetComponent<Rotate>().from = cube.transform;
            rotator.GetComponent<Rotate>().to = positions[currentPosition].transform;
            cube.GetComponent<MeshRenderer>().material = this.cubeRotating;
        }
        else if(active && rotator.GetComponent<Rotate>().to == null)
        {
            cube.GetComponent<MeshRenderer>().material = this.cubeSelected;
        }
    }

    public void Activate()
    {
        this.active = true;
        this.cube.GetComponent<MeshRenderer>().material = this.cubeSelected;
    }

    public void Deactivate()
    {
        this.active = false;
        this.cube.GetComponent<MeshRenderer>().material = this.cubeIdle;

    }

    public void ActorEntered()
    {
        Deactivate();
        actorEntered = true;

        Transform tile = GetActiveTile();
        GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        controller.DoDamage(tile.GetComponent<Tile>().damage);
    }

    private Transform GetActiveTile()
    {
        Transform max = tiles[0];
        foreach(Transform tile in tiles)
        {
            if (tile.position.y > max.position.y) max = tile;
        }

        return max;
    }
}
