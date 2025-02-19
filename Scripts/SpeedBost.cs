using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    private Animator animator;

    public float pushForce = 500; // Fuerza del empujón

    public bool Pushed = false;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Colisión detectada con: " + other.gameObject.name); // Ver si detecta el jugador

        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Animator anim = other.GetComponent<Animator>();
            
            anim.SetBool("Pushed", true);

            if (rb != null)
            {
                Pushed = true;
                // Usa la orientación de la rampa en lugar de calcularla con la posición del jugador
                Vector3 pushDirection = transform.forward; 
                pushDirection.y = 0; // Evita que empuje hacia arriba o abajo
                pushDirection.Normalize(); // Asegura que la dirección tiene magnitud 1

                rb.AddForce(pushDirection * pushForce, ForceMode.Impulse); // Aplica empujón

                Debug.Log("¡Empujón aplicado en dirección: " + pushDirection);
            }
            
        }
        Pushed = false;
    }
}
