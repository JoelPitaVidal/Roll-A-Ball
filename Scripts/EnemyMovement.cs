using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    // Reference to the player's transform.
    public Transform player;

    // Reference to the NavMeshAgent component for pathfinding.
    private NavMeshAgent navMeshAgent;

    // Reference to the UI object to display losing text.
    public GameObject loseTextObject;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the NavMeshAgent component attached to this object.
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame.
    void Update()
    {
        // If there's a reference to the player...
        if (player != null)
        {
            // Set the enemy's destination to the player's current position.
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object the enemy collided with has the "Player" tag.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the player object.
            Destroy(collision.gameObject);

            // Display the lose text.
            loseTextObject.SetActive(true);
            loseTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";

            // Pause the game.
            Time.timeScale = 0f;
        }
    }
}
