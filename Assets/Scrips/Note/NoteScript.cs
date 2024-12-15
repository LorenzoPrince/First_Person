using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour

{
    public GameObject NoteCube;
    public bool active;
    public GameObject PressE;

    void Update()
    {
        if(active && !NoteCube.activeSelf) //revisa que no este activado el objeto de la ui.
        {
            PressE.SetActive(true);
        }
        else if(NoteCube.activeSelf) 
        {
            PressE.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.E)&& active == true && !NoteCube.activeSelf)
        {
            NoteCube.SetActive(true);
            PressE.SetActive(false);
            Debug.Log("desactiva");
        }
        if(Input.GetKeyDown(KeyCode.Escape) && NoteCube.activeSelf)
        {
            NoteCube.SetActive(false); // si esta adentro sale
            Cursor.visible = false;
            PressE.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other) // si entra
    {
        if (other.tag == "Player") //si lo que entra tiene el tag pum
        {
            active = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            active = false;
            NoteCube.SetActive(false); // hace si se aleja desaparece la nota de la camara
            PressE.SetActive(false); // Desactivamos la indicación de presionar E cuando el jugador ya no está cerca
        }
    }
    
}
