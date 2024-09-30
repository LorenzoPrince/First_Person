using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    public int Health;

    private void OnCollisionEnter(Collision collision)
    {
        int receivedaDamage = collision.gameObject.GetComponent<Bullet>().damage;
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("pego");
            Destroy(collision.gameObject);
    

            Health -= receivedaDamage;

            if (Health <= 0)
            {
                Debug.Log("muere");
                Destroy(collision.gameObject); 
            }
        }

    }

    
}
