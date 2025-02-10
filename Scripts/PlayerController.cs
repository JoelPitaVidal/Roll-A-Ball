using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Variable to keep track of collected "PickUp" objects.
    private int count;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 0;

    // Jump force for the player.
    public float jumpForce = 5.0f;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;

    // UI object to display winning text.
    public GameObject winTextObject;

    // Variable to enable flying
    private bool canFly = false;

    // Speed of flight
    public float flightSpeed = 10.0f;

    // GameObject de la pared que debe desaparecer.
    public GameObject wallToDisappear;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>(); rb.constraints = RigidbodyConstraints.FreezeRotation; // Asegurarse de no restringir el movimiento vertical
        // Initialize count to zero.
        count = 0;

        // Update the count display.
        SetCountText();

        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // This function is called when a jump input is detected.
    void OnJump(InputValue jumpValue)
    {
        // Check if the player is grounded before allowing to jump.
        if (IsGrounded())
        {
            // Apply upward force to the Rigidbody to make the player jump.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Function to check if the player is grounded.
    bool IsGrounded()
    {
        // Check if the player is touching the ground using a raycast.
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);

        // Added flying logic
        if (canFly && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Flying!");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, flightSpeed, rb.linearVelocity.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {

         // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
        
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

            // Increment the count of "PickUp" objects collected.
            count = count + 1;

            Debug.Log("Pick-Up collected");
            // Update the count display.
            SetCountText();
        }
        // Added logic to check for FlyingPowerUp
        else if (other.gameObject.CompareTag("FlyingPowerUp"))
        {
            other.gameObject.SetActive(false);
            EnableFlying();
        }
    }

    public void EnableFlying()
    {
        canFly = true;
    }

    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();
                    if (wallToDisappear != null && count == 4)
            {
                wallToDisappear.SetActive(false);
            }


        // Check if the count has reached or exceeded the win condition.
        if (count >= 8)
        {
            // Display the win text.
            winTextObject.SetActive(true);

            // Desactiva el GameObject de la pared.


            // Destroy the enemy GameObject.
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);

            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
}
