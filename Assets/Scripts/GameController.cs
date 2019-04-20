using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform[] segments;
    int currentPosition = 0;
    int progress = 0;
    public GameObject actor;
    public GameObject healthbar;
    public int health;
    public GameObject explosionPrefab;
    public GameObject chest;
    public GameObject retryMenu;

    // Start is called before the first frame update
    void Start()
    {
        segments[0].GetComponent<SegmentControler>().Activate();
        actor.GetComponent<Actor>().Go();
        healthbar.GetComponent<Slider>().value = health;
    }

    // Update is called once per frame
    void Update()
    {
        progress = 0;
        foreach(Transform segment in segments)
        {
            if (segment.GetComponent<SegmentControler>().actorEntered) progress++;
        }

        if (currentPosition < progress && progress <= segments.Length - 1)
        {
            currentPosition = progress;
            segments[currentPosition].GetComponent<SegmentControler>().Activate();
        }

        if (Input.GetButtonDown("SegmentSelection"))
        {
            segments[currentPosition].GetComponent<SegmentControler>().Deactivate();

            currentPosition += (Input.GetAxis("SegmentSelection") > 0) ? 1 : -1;
            if (currentPosition < progress) currentPosition = segments.Length - 1;
            else if (currentPosition >= segments.Length) currentPosition = progress;


            segments[currentPosition].GetComponent<SegmentControler>().Activate();
        }
    }

    public void DoDamage(int damage)
    {
        health = (damage > health) ? 0 : health - damage;
        healthbar.GetComponent<Slider>().value = health;

        if(health == 0)
        {
            ActorExplode();
            retryMenu.gameObject.SetActive(true);
        }
    }

    public void ActorExplode()
    {
        Vector3 pos = actor.transform.position;
        Destroy(actor);
        GameObject explosion = Instantiate(explosionPrefab, pos, transform.rotation);
        retryMenu.gameObject.SetActive(true);
    }

    public void GoalEntered()
    {
        print("Yay");

        Vector3 pos = chest.transform.position;
        Destroy(chest);
        GameObject explosion = Instantiate(explosionPrefab, pos, transform.rotation);

        Invoke("ActorExplode", 6);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
