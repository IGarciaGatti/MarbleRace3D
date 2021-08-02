using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : Fluid
{
    private void Start()
    {
        CalculateDensity();
    }

    private void OnTriggerEnter(Collider sphereCollider)
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            if (sphereCollider == spheres[i].GetComponent<Collider>())
            {
                spheres[i].EnterLiquid(true, density);
            }
        }
    }

    private void OnTriggerExit(Collider sphereCollider)
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            if (sphereCollider == spheres[i].GetComponent<Collider>())
            {
                spheres[i].EnterLiquid(false, 0);
            }
        }
    }
}
