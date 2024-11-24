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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            CloseDoor();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenDoor();
        }
    }
    public void OpenDoor()
    {
        doorAnimator.SetBool("Open", true);
    }
    public void CloseDoor()
    {
        doorAnimator.SetBool("Open", false);
    }
    public void SwitchDoor(bool State)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
    }
}
