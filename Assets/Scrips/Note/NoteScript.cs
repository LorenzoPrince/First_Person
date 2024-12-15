using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour

{
    public GameObject NoteCube;
    public bool active;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& active == true)
        {
            NoteCube.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && active == true)
        {
            NoteCube.SetActive(false); // si esta adentro sale
        }
    }
    private void OnTriggerEnter(Collider other) // si entra
    {
        if (other.tag == "Player") //si lo que entra tiene el tag pum
        {
            active = true;
        }
    }
}
