using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CheckpointState { Inactive, Active, Complete }
public class Checkpoint : MonoBehaviour
{   
    public CheckpointState CurrentState;
    protected List<Sphere> spheres;
    [SerializeField] protected float fallLimit;
    [SerializeField] protected int sphereLimit;
    [SerializeField] protected bool sphereStopChecking;
    protected Vector3 respawnPoint;
    [SerializeField] protected Vector3 respawnPointOffset;
    [SerializeField] protected bool usingCustomRespawnPoint;
    [SerializeField] protected Vector3 customRespawnPoint;   
    protected int sphereCount;

    private void Start()
    {
        AdjustFallLimit();
    }

    public void SetSpheres(List<Sphere> spheres)
    {
        this.spheres = spheres;
    }

    public void ChangeCurrentState(CheckpointState newState)
    {
        CurrentState = newState;
    }
    
    private void AdjustFallLimit()
    {
        if (usingCustomRespawnPoint)
        {
            respawnPoint = customRespawnPoint;
        }
        else
        {
            respawnPoint = transform.position + respawnPointOffset;
        }
    }

    private void CheckCompletion()
    {
        if (sphereCount >= sphereLimit)
        {
            ChangeCurrentState(CheckpointState.Complete);      
        }       
    }

    private void OnTriggerEnter(Collider sphereCollider)
    {
        CollisionWithSphere(sphereCollider);     
        CheckCompletion();
    }

    public virtual void CollisionWithSphere(Collider sphereCollider)
    {
        for (int i = 0; i < spheres.Count; i++)
        {
            if (sphereCollider == spheres[i].GetComponent<Collider>())
            {
                if (sphereCount < 1)
                {
                    ChangeCurrentState(CheckpointState.Active);
                }               
                spheres[i].SetRespawn(respawnPoint, fallLimit, sphereStopChecking);                
                sphereCount += 1;               
            }
        }
    }
}
