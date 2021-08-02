using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCurrent : Fluid
{
    [SerializeField] private float velocity;
    [SerializeField] private float angle;
    private float dynamicPressure;

    private void Start()
    {
        CalculateDensity();
        CalculatePressure();
    }

    private void CalculatePressure()
    {
        dynamicPressure = 0.5f * density * velocity * velocity;
    }

    private void OnTriggerEnter(Collider sphereCollider)
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            if (sphereCollider == spheres[i].GetComponent<Collider>())
            {
                spheres[i].EnterAirCurrent(true, density, dynamicPressure, angle);
            }
        }
    }

    private void OnTriggerExit(Collider sphereCollider)
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            if (sphereCollider == spheres[i].GetComponent<Collider>())
            {
                spheres[i].EnterAirCurrent(false, 0, 0, 0);
            }
        }
    }
}
