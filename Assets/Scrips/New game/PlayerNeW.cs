using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNew : MonoBehaviour
{
    // Start is called before the first frame update

    public float Jumpforce;
    public float speed;
    private float defaultSpeed;
    public UnityEngine.Vector3 imputVector;
    public bool isGrounded;
    public Collision contraLoQueChoque;
    public Rigidbody rigidBody;
    [SerializeField] Gameover Menu;
    private AudioSource audioSource;
    private Coroutine corutine;
    private bool caminando;

    void Start()
    {
        Debug.Log("el juego a inciado");
        rigidBody = GetComponent<Rigidbody>();
        isGrounded = true;
        audioSource = GetComponent<AudioSource>();
        defaultSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        imputVector.x = Input.GetAxis("Horizontal");
        imputVector.y = Input.GetAxis("Vertical");



        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = defaultSpeed * 7;
        }
        else
        {
            speed = defaultSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.AddForce(0f, Jumpforce, 0f, ForceMode.Impulse);
            isGrounded = false;
        }
        rigidBody.AddRelativeForce(imputVector.x * speed, 0f, imputVector.y * speed, ForceMode.Impulse); // usar relative force para que detecte el eje propio no el del mundo.
        if (imputVector.x != 0 || imputVector.y != 0)
        {
            if (!caminando)
            {
                caminando = true;
                corutine = StartCoroutine(pisadas());
                audioSource.Play();
            }
        }
        else
        {
            if (caminando) 
            {
                caminando = false; // El jugador no está caminando
                StopCoroutine(corutine);
            }

        }

    }

    private void OnCollisionEnter(Collision contraLoQueChoque)//metedo de unity para detectar collisiones
    {
        Debug.Log("choque contra " + contraLoQueChoque.gameObject.name);
        if (contraLoQueChoque.gameObject.CompareTag("pizo"))
        {
            isGrounded = true;
        }
        if (contraLoQueChoque.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("kill you");
            //Menu.ActiveScreenLose(); //activa del otro script la funcion  lo saco ya que era del anterior juego
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Final"))
        {
            // Cambiar de escena, reemplaza "SceneName" con el nombre de tu escena
            Invoke("scene", 2f);
        }
    }
    IEnumerator pisadas() // hago corrutina
    {
        while(true) //bucle
        {
            yield return new WaitForSeconds(1f); // no explota pq espero un segundo
            audioSource.Play();
        }

    }
    private void scene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
