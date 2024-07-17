using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherFlashlight : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float positionSmoothSpeed = 0.125f;
    [SerializeField] private float rotationSmoothSpeed = 5f;

    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    private void Start()
    {
        // Set the desired position and rotation of the flashlight to be offset from the camera
        desiredPosition = cameraTransform.position + offset;
        desiredRotation = cameraTransform.rotation;
    }

    private void Update()
    {

        // Update the desired position and rotation of the flashlight to be offset from the camera
        desiredPosition = cameraTransform.position + offset;
        desiredRotation = Quaternion.LookRotation(cameraTransform.forward);

        // Smoothly move the flashlight towards the desired position using Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed);
        transform.position = smoothedPosition;

        // Smoothly rotate the flashlight towards the desired rotation using Slerp
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed * Time.deltaTime);
        transform.rotation = smoothedRotation;
    }
}