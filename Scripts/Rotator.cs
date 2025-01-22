using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    // Velocidad de rotación lateral (alrededor del eje Y)
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotar el objeto solo alrededor del eje Y
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
