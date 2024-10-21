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

    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private TextMeshProUGUI winText;
    void Start()
    {
        winText.enabled = false;

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
            win();
            Time.timeScale = 0;
        }

    }
    private void updateUI()
    {
        killText.text = kills.ToString() + " / " + TotalEenemy.ToString();
    }
    private void win()
    {
        winText.enabled = true;
    } 
}
