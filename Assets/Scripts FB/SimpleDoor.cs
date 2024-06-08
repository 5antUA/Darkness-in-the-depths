using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    private Animator anim;
    public float distance;
    public bool isOpen {  get; set; }

    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = false;
    }

    public void OpenDoor()
    {
        anim.SetBool("isOpen", true);
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
        anim.SetBool("isOpen", false);
    } 
}
