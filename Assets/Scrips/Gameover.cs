using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //aunque no use scenas es importante para pausarlo.
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Lose; // permite que una varible sea publica sin aparecer en el inspector
    void Start()
    {
        Lose.SetActive(false);
    }
    public void ActiveScreenLose()
    {
        Lose.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //obtiene la scena que esta activa actualmente y la reinicia.
    }              //recarga la scena                        // detecta la scene

    // Update is called once per frame

}
