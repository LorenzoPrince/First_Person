using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float Jumpforce;
    public float speed;
    public UnityEngine.Vector3 imputVector;
    public bool isGrounded;
    public Collision contraLoQueChoque;
    public Rigidbody rigidBody;

    void Start()
    {
        Debug.Log("el juego a inciado");
        rigidBody = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        imputVector.x = Input.GetAxis("Horizontal");
        imputVector.y = Input.GetAxis("Vertical");


        rigidBody.AddRelativeForce(imputVector.x * speed, 0f, imputVector.y * speed, ForceMode.Impulse); // usar relative force para que detecte el eje propio no el del mundo.

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rigidBody.AddForce(0f, Jumpforce, 0f, ForceMode.Impulse);
            isGrounded = false;
        }

    }
    private void OnCollisionEnter(Collision contraLoQueChoque)//metedo de unity para detectar collisiones
    {
        Debug.Log("choque contra " + contraLoQueChoque.gameObject.name);
        if (contraLoQueChoque.gameObject.CompareTag("pizo"))
        {
            isGrounded = true;
        }
    }
}
