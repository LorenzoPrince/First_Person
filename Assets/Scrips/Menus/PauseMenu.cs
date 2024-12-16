using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPausa;  // Referencia al Canvas del menú de pausa
    private bool estaPausado = false;  

    void Start()
    {
      
        menuPausa.SetActive(false);
    }

    void Update()
    {
        // Verifica si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    void PausarJuego()
    {
        Time.timeScale = 0f;  // Detiene el tiempo del juego
        menuPausa.SetActive(true);  // Muestra el menú de pausa
        estaPausado = true;  
    }

    void ReanudarJuego()
    {
  
        Time.timeScale = 1f;  // Reanuda el tiempo del juego
        menuPausa.SetActive(false);  // Oculta el menú de pausa
        estaPausado = false;  
    }


    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
