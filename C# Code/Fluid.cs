using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid : MonoBehaviour
{
    protected List<Sphere> spheres;
    [SerializeField] protected float mass;
    protected float density;
    protected float volume;
    protected Vector3 colliderSize;

    public void SetSpheres(List<Sphere> spheres)
    {
        this.spheres = spheres;
    }

    protected void CalculateDensity()
    {       
        colliderSize = GetComponent<BoxCollider>().size;        
        volume = colliderSize.x * colliderSize.y * colliderSize.z;
        density = mass / volume;
    }
}
