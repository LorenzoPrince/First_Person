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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SetDestination", initialDelay, interval); //me permite llamar a un meto dentro de un tiempo metodo de la clase. Si pongo repeting puedo agregar tambien cada cuanto se tiene que repetir.

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void SetDestination()
    {
        agent.destination = player.position;
    }
}
