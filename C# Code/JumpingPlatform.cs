using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    private Rigidbody body;
    private Vector3 force;
    [SerializeField] private Vector3 acceleration;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        force = body.mass * acceleration;
    }

    public void Activate()
    {
        body.AddForce(force);
    }
}
