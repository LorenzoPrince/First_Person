using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //aunque no use scenas es importante para pausarlo.
using UnityEngine.UI;
public class Gameover : MonoBehaviour
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
        StartCoroutine(RestartAfterDelay(2f)); // Llama a la coroutine para reiniciar despu�s de 5 segundos
    }


    private IEnumerator RestartAfterDelay(float delay)
    {
        Debug.Log("Esperando para reiniciar...");
        yield return new WaitForSeconds(delay); // Espera el tiempo especificado
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");  //obtiene la scena que esta activa actualmente y la reinicia.
    }              //recarga la scena                        // detecta la scene



}
