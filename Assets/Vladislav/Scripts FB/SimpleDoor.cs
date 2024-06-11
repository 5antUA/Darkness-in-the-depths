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

    public void Open()
    {
        anim.SetBool("isOpen", true);
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
        anim.SetBool("isOpen", false);
    } 
}
