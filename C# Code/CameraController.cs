using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private enum RotationStates { First, Second, Third, Fourth, Fifth, Sixth, Seventh, Eighth }
    private RotationStates CurrentState;
    private Transform playerTransform;
    [SerializeField] private Vector3 firstPosition;
    [SerializeField] private Vector3 secondPosition;
    [SerializeField] private Vector3 thirdPosition;
    [SerializeField] private Vector3 fourthPosition;
    [SerializeField] private Vector3 fifthPosition;
    [SerializeField] private Vector3 sixthPosition;
    [SerializeField] private Vector3 seventhPosition;
    [SerializeField] private Vector3 eighthPosition;
    private Vector3 currentOffset;

    private void Start()
    {
        currentOffset = firstPosition;
    }

    void Update()
    {
        UpdatePosition();
    }

    public void SetPlayerTransform(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }

    public void UpdatePosition()
    {
        transform.position = playerTransform.position + currentOffset;
    }

    public void RotateCameraLeft()
    {
        transform.Rotate(0, 45, 0);
        switch (CurrentState)
        {
            case RotationStates.First:
                currentOffset = secondPosition;
                CurrentState = RotationStates.Second;
                break;

            case RotationStates.Second:
                currentOffset = thirdPosition;
                CurrentState = RotationStates.Third;
                break;

            case RotationStates.Third:
                currentOffset = fourthPosition;
                CurrentState = RotationStates.Fourth;
                break;

            case RotationStates.Fourth:
                currentOffset = fifthPosition;
                CurrentState = RotationStates.Fifth;
                break;

            case RotationStates.Fifth:
                currentOffset = sixthPosition;
                CurrentState = RotationStates.Sixth;
                break;

            case RotationStates.Sixth:
                currentOffset = seventhPosition;
                CurrentState = RotationStates.Seventh;
                break;

            case RotationStates.Seventh:
                currentOffset = eighthPosition;
                CurrentState = RotationStates.Eighth;
                break;

            case RotationStates.Eighth:
                currentOffset = firstPosition;
                CurrentState = RotationStates.First;
                break;
        }
    }
  
    public void RotateCameraRight()
    {
        transform.Rotate(0, -45, 0);
        switch (CurrentState)
        {
            case RotationStates.First:
                currentOffset = eighthPosition;
                CurrentState = RotationStates.Eighth;
                break;

            case RotationStates.Second:
                currentOffset = firstPosition;
                CurrentState = RotationStates.First;
                break;

            case RotationStates.Third:
                currentOffset = secondPosition;
                CurrentState = RotationStates.Second;
                break;

            case RotationStates.Fourth:
                currentOffset = thirdPosition;
                CurrentState = RotationStates.Third;
                break;

            case RotationStates.Fifth:
                currentOffset = fourthPosition;
                CurrentState = RotationStates.Fourth;
                break;

            case RotationStates.Sixth:
                currentOffset = fifthPosition;
                CurrentState = RotationStates.Fifth;
                break;

            case RotationStates.Seventh:
                currentOffset = sixthPosition;
                CurrentState = RotationStates.Sixth;
                break;

            case RotationStates.Eighth:
                currentOffset = seventhPosition;
                CurrentState = RotationStates.Seventh;
                break;
        }
    }

}
