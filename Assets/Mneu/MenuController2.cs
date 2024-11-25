using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController2 : MonoBehaviour
{

    public void PlayAgain()
    {
        Debug.Log("PlayAgain llamado");

        // Asegúrate de desbloquear el cursor
        Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor
        Cursor.visible = true;                   // Hace el cursor visible

        Time.timeScale = 1f; // Asegura que el tiempo esté corriendo
        Debug.Log("Tiempo corriendo");
        SceneManager.LoadScene(1);
    }
}
