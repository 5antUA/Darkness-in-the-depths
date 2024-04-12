using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class ThrowRay : MonoBehaviour
{
    public RaycastHit GetHit(float distance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out RaycastHit hit, distance);

        return hit;
    }
}
