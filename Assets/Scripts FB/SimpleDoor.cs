using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    private Animator anim;
    public LayerMask layer;
    public float distance;
    private Camera cam;
    private bool isOpen;
    public bool isLocked;

    void Start()
    {
        anim = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
        isOpen = false;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform .position, cam.transform.forward);
        if(Physics.Raycast(ray, out hit, distance, layer))
        {
            if (Input.GetKeyDown(KeyCode.E) && !isOpen && !isLocked)
            {
                anim.SetBool("isOpen", true);
                isOpen = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isOpen && !isLocked)
            {
                isOpen = false;
                anim.SetBool("isOpen", false);
            }
        }
    }
}
