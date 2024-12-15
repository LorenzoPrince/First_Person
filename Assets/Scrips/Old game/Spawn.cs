using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float bulletForce; //es para que sea privado pero se siga viendo en el inspector y editarlo, pero no podes editarlo en otro script. 
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private GameObject shootVFXPrefab; // Prefab de las partículas del disparo
    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(objectPrefab, transform.position, transform.rotation); // el quaternion. identity es para que sea en la misma posicion que el vector . y el vector que esta el spawn
 

            Rigidbody bulletRigidBody = bulletClone.GetComponent<Rigidbody>(); //rigid body de la nueva bala

            bulletRigidBody.velocity = transform.forward * bulletForce; // impulso de la bala multiplicado por el bulletforce


            GameObject shootVFXClone = Instantiate(shootVFXPrefab, transform.position, transform.rotation);
            // Instanciar el efecto de partículas en la misma posición del disparo
            Destroy(shootVFXClone, 0.5f);
            Destroy(bulletClone, 2f);
            // en el prefab de la bala hago que si se choca contra algo se elimine la bala pero esto en el prefab
        }
    }


    
}
