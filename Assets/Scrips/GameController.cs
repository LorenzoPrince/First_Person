using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int kills;
    public int TotalEenemy;
    private int round = 1;


    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI Round;
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private Transform spawnPoint; 
    void Start()
    {
        winText.enabled = false;
        Round.enabled = false;
        TotalEenemy = GameObject.FindGameObjectsWithTag("Enemy").Length; //me hace una array de todos los objeytos que tengan este tag y los cuenta por el Lenght en una array, count sirve para lista
        
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addKill() //void pq no devuelve valor //este es publico pq lo llamamos desde afuera desde enemy
    {
        kills++;
        updateUI();

        if (kills >= TotalEenemy)
        {
            if (round == 3)
            {
                Restart();



            }
            nextWave();

        }

    }
    private void updateUI()
    {
        killText.text = kills.ToString() + " / " + TotalEenemy.ToString();
    }

    private void win()
    {
        winText.enabled = true;
        Time.timeScale = 0;
        Round.enabled = false;
 

    }
    private void Restart()
    {
        Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor
        Cursor.visible = true;
        SceneManager.LoadScene("Win"); 
    }
    private void nextWave()
    {
        Round.enabled = true;
        StartCoroutine(WaitAndDisableRound(3f));
        newRound();
    }
    private IEnumerator WaitAndDisableRound(float waitTime)
    {
        Debug.Log("next");
        yield return new WaitForSeconds(waitTime); // Espera el tiempo especificado
        Round.enabled = false;

    }
    private void newRound()
    { 
        round++;
        Round.text =  " Round " + round.ToString(); //aclarar . text para que ande
        TotalEenemy++;
        kills = 0;
        newEnemy();
    }
    private void newEnemy()
    {
        for (int i = 0; i < TotalEenemy; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity); // Spawnea enemigo en la posición definida
        }

        updateUI();
    }
}
