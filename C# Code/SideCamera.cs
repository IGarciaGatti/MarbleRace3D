using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCamera : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = playerTransform.position + offset;
    }

    public void SetPlayerTransform(Transform transform)
    {
        playerTransform = transform;
    }
}
