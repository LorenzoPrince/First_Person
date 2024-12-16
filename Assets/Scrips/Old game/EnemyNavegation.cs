using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavegation : MonoBehaviour
{
    public NavMeshAgent agent;// Componente que controla el movimiento del enemigo
    public Transform player;// Transform del jugador al que el enemigo seguirá
    public float initialDelay; //tiemmpo para que inicie
    public float interval; //cada cuanto chequea a donde ir
    public float detectionRange = 40f; // Rango de detección
    private bool playerInRange = false; //verificacion si el enemigo esta cerca del player
    private Canvas enemyCanvas;  // El Canvas asociado al enemigo

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyCanvas = GetComponentInChildren<Canvas>();
        //InvokeRepeating("SetDestination", initialDelay, interval); //me permite llamar a un meto dentro de un tiempo metodo de la clase. Si pongo repeting puedo agregar tambien cada cuanto se tiene que repetir.
        enemyCanvas.gameObject.SetActive(false);

    }
    private void Update()
    {
        CheckPlayerDistance();
    }
    // Update is called once per frame
    void CheckPlayerDistance() //funcion que chequea la distancia
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); //calcula la distancia del player
        if (distanceToPlayer <= detectionRange) // Si el jugador está dentro del rango
        {
            enemyCanvas.gameObject.SetActive(true);
            playerInRange = true;
            SetDestination(); // Mueve al enemigo hacia el jugador

        }
        else
        {

            agent.ResetPath(); // Detiene el movimiento si el jugador está fuera de rango
        }
    }


    public void SetDestination()
    {
        if (playerInRange == true)
    {
        agent.destination = player.position;
    }
       
    }
}
