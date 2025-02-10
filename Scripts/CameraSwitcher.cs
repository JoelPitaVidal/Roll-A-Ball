using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // Array para todas las cámaras
    private int currentCameraIndex = 0; // Índice de la cámara actual

    void Start()
    {
        // Asegúrate de que solo una cámara esté activa al inicio
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        // Cambiar de cámara al presionar el botón (por defecto 'C')
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Length)
                currentCameraIndex = 0;

            ActivateCamera(currentCameraIndex);
        }
    }

    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }
}

