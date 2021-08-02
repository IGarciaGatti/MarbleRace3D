using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private enum SphereState { Normal, Submerged, FacingWind }
    private SphereState CurrentState;
    private Rigidbody body;
    private bool isPlayer;
    private float fallLimit;
    private Vector3 respawnPoint;
    private float radius;
    private float area;
    private float volume;
    private float density;
    private float liquidDensity;
    private Vector3 upthrust;
    private float airDensity;
    private float airDynamicPressure;
    private float dragCoefficient;
    private float dragForce;
    private float angle;
    [SerializeField] private float timeToRespawn;
    private bool stopChecking;
    private float stoppedCount;
    public bool IsPlayer => isPlayer;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.maxAngularVelocity = 500f;
        CalculateValues();
    }
    
    void LateUpdate()
    {
        PhysicsEffects();
        CheckBounds();
        DetectStop();
    }

    public void SetPlayerStatus(bool status)
    {
        isPlayer = status;
    }

    public void EnterLiquid(bool isSubmerged, float liquidDensity)
    {
        this.liquidDensity = liquidDensity;
        if (isSubmerged)
        {
            CurrentState = SphereState.Submerged;
            body.useGravity = false;
        }
        else
        {
            CurrentState = SphereState.Normal;
            body.useGravity = true;
        }
    }

    public void EnterAirCurrent(bool crossingCurrent, float airDensity, float airDynamicPressure, float angle)
    {
        this.airDensity = airDensity;
        this.airDynamicPressure = airDynamicPressure;
        this.angle = angle;
        if (crossingCurrent)
        {
            CurrentState = SphereState.FacingWind;
        }
        else
        {
            CurrentState = SphereState.Normal;
        }
    }

    private void CalculateValues()
    {
        radius = GetComponent<SphereCollider>().radius;
        dragCoefficient = GetComponent<Rigidbody>().drag;
        area = 3.1416f * radius * radius;
        volume = 4f/3f * 3.1416f * radius * radius * radius;
        density = body.mass / volume;
    }

    private void PhysicsEffects()
    {
        if (CurrentState == SphereState.Submerged)
        {
            upthrust = Physics.gravity * (volume * (liquidDensity - density));
            body.AddForce(upthrust);
        }
        else if(CurrentState == SphereState.FacingWind)
        {
            float speed = body.velocity.magnitude;
            float windLoad = airDynamicPressure * area * Mathf.Sin(angle);
            dragForce = dragCoefficient * 0.5f * airDensity * speed * speed * area;

            body.AddForce(new Vector3(0f, 0f, windLoad));
            body.AddForce(new Vector3(0f, 0f, dragForce));
        }
    }

    public void SetRespawn(Vector3 position, float fallLimit, bool stopChecking)
    {
        respawnPoint = position;
        this.fallLimit = fallLimit;
        this.stopChecking = stopChecking;
    }
    
    public void Respawn()
    {
        Vector3 stop = new Vector3(0, 0, 0);
        body.velocity = stop;
        body.angularVelocity = stop;
        transform.position = respawnPoint;
    }

    private void CheckBounds()
    {
        if (transform.position.y < fallLimit)
        {
            Respawn();
        }
    }

    private void DetectStop()
    {
        if (stopChecking && !isPlayer)
        {
            if(body.velocity.magnitude <= 0)
            {
                stoppedCount += Time.fixedDeltaTime;
                if(stoppedCount > timeToRespawn)
                {
                    Respawn();
                    stoppedCount = 0;
                }
            }
            else
            {
                stoppedCount = 0;
            }
        }
    }
}
