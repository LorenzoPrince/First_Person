using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject impactVFXPrefab;
    public int damage = 25;

    private void OnCollisionEnter(Collision contraLoQueChoque)
    {
        if (impactVFXPrefab != null)
        {
            // Obtener el punto de contacto de la colisi�n
            ContactPoint contacto = contraLoQueChoque.contacts[0];
            // Instanciar el efecto de part�culas en el lugar donde ocurri� la colisi�n
            GameObject impactVFXClone = Instantiate(impactVFXPrefab, contacto.point, Quaternion.LookRotation(contacto.normal));
            Destroy(impactVFXClone, 1f);  // Destruir las part�culas despu�s de 1 segundo
        }
        Debug.Log("la Bala choco con: " + contraLoQueChoque.gameObject.name);
        Destroy(gameObject);
    }

}

