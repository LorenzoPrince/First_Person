using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    public int Health;
    public TextMeshProUGUI enemyHealthUI; // permitimos arrastar el texto para que se refiea enemy... al texto.
    public GameController gameController;
    private void Start()
    {
        UpdateUI();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            int receivedaDamage = collision.gameObject.GetComponent<Bullet>().damage;
            Debug.Log("pego " + receivedaDamage);
            Destroy(collision.gameObject);
    

            Health -= receivedaDamage;
            Debug.Log(Health);
            UpdateUI();

            if (Health <= 0)
            {
                Debug.Log("muere");
                gameController.addKill(); //la llamo del otro script de gamecontroller
                Destroy(gameObject); 
            }
        }

    }

    private void UpdateUI()
    {
        enemyHealthUI.text = Health.ToString(); //covertimos en texto el valor de la vida y transformamos el valor de tmpro en este.
    }


}
