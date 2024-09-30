using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float bulletForce;
    public GameObject objectPrefab;
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

            Destroy(bulletClone, 2f);
        }
    }
}
