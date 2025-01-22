using UnityEngine;

public class FlyingPowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            // Verificar si playerController no es nulo antes de usarlo
            if (playerController != null)
            {
                playerController.EnableFlying();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("PlayerController not found on the player object.");
            }
        }
    }
}
