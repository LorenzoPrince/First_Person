using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacter : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtener la entrada de movimiento (Horizontal y Vertical)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Convertir el movimiento en relación con la rotación del jugador (espacio local)
        move = transform.TransformDirection(move) * playerSpeed;

        // Aplicar el movimiento usando CharacterController.Move()
        controller.Move(move * Time.deltaTime);

        // Aplicar gravedad manualmente
        if (controller.isGrounded)
        {
            velocity.y = -2f;  // Asegurar que el personaje esté pegado al suelo
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;  // Aplicar gravedad cuando no está en el suelo
        }

        // Mover al personaje hacia abajo con la gravedad
        controller.Move(velocity * Time.deltaTime);

        // Desbloquear el cursor cuando se presiona Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
