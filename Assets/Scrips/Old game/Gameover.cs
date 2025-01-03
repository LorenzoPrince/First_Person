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
        Time.timeScale = 0f; // Detiene el tiempo
        StartCoroutine(RestartAfterDelay(2f)); // Llama a la coroutine para reiniciar despu�s de 2 segundos
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        Debug.Log("Esperando para reiniciar...");
        yield return new WaitForSecondsRealtime(delay); // Espera el tiempo especificado
        Debug.Log(" reiniciar...");
        Time.timeScale = 1f; // Reanuda el tiempo
        Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor
        Cursor.visible = true;
        Debug.Log(" reinicio...");
        SceneManager.LoadScene(2);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reinicia la escena
    }
}
