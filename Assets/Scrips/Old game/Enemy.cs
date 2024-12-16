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
    public GameController gameController; // detecta cual es el jugador
    public GameObject hitVFXprefab;  // Prefab de partículas para el impacto
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
            // Instanciar el efecto de partículas en el punto de colisión
            GameObject hitVFXClone = Instantiate(hitVFXprefab, transform.position, Quaternion.identity);
            Destroy(hitVFXClone, 2f);
            Destroy(collision.gameObject);     // Destruir la bala



            Health -= receivedaDamage;
            Debug.Log(Health);
            UpdateUI();

            if (Health <= 0)
            {
                Debug.Log("muere");
<<<<<<< Updated upstream
               // gameController.addKill(); //la llamo del otro script de gamecontroller
=======
                //gameController.addKill(); //la llamo del otro script de gamecontroller esto lo usaba antes para hacer el contador de kill
>>>>>>> Stashed changes
                Destroy(gameObject); 
            }
        }

    }

    private void UpdateUI()
    {
        enemyHealthUI.text = Health.ToString(); //covertimos en texto el valor de la vida y transformamos el valor de tmpro en este.
    }


}
