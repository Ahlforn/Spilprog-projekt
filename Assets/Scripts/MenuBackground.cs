using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBackground : MonoBehaviour
{
    public int minimumDistance;
    public int maximumDistance;
    public int backgroundCubeAmount;
    public GameObject cubePrefab;
    private GameObject[] cubes;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        cubes = new GameObject[backgroundCubeAmount];
        camera = gameObject.GetComponent<Camera>();

        // Create and instantiate cubes in the pool, with random start positions
        for (int i = 0; i < cubes.Length; i++)
        {
            float x = Random.Range(0.0f, 1.0f);
            float y = Random.Range(0.0f, 1.0f);
            float z = Random.Range(minimumDistance, maximumDistance);
            Vector3 pos = camera.ViewportToWorldPoint(new Vector3(x, y, z));
            GameObject cube = Instantiate(cubePrefab, pos, Quaternion.identity) as GameObject;
            cubes[i] = cube;
        }

        BackgroundCubeObject.exitFromView = Reposition;
    }

    void Reposition(GameObject cube)
    {
        if (camera)
        {
            float x = Random.Range(0.0f, 1.0f);
            float y = 1.1f;
            float z = Random.Range(minimumDistance, maximumDistance);
            Vector3 pos = camera.ViewportToWorldPoint(new Vector3(x, y, z));
            cube.transform.position = pos;
        }
    }

    // Menu buttons. Logic should maybe be put in a controller, but it's very limited.
    public void NewGame()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
