using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimationControler : MonoBehaviour
{
    // Start is called before the first frame update
    Animator doorAnimator;
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }


    public void SwitchDoor(bool State)
    {
        doorAnimator.SetBool("Open",State); // codigo mas limpio queda que hacer uno de open y otro de closet
    
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
    }
}
