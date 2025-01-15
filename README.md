# Roll-A-Ball

## Descripción
En esste roll a ball, contamos con un pequeño circuíto de obstáculos que esquivar y saltar:

![alt text](https://github.com/JoelPitaVidal/Roll-A-Ball/blob/main/RollABall/Captura%20de%20pantalla%202025-01-15%20200201.jpg))

## Player

Contamos con un jugador, que consta de una esféra azúl con la capacidad de moverse en todas direcciónes y saltar, esto se hace grácias al script PlayerController, que consta de las siguientes partes:

```
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
```
