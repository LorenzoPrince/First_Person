using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavegation : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float initialDelay;
    public float interval;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SetDestination", 2f, 1f); //me permite llamar a un meto dentro de un tiempo metodo de la clase. Si pongo repeting puedo agregar tambien cada cuanto se tiene que repetir.

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
