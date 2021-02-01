using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters per second")] [SerializeField] float xSpeed = 4f;
    [Tooltip("movement limits")] [SerializeField] float xClamp = 0.35f;
    [Tooltip("movement limits")] [SerializeField] float yClampMin = 0.20f;
    [Tooltip("movement limits")] [SerializeField] float yClampMax = 0.25f;

    // to have the right rotation we need to modify the rotation values in the DroneRotation method
    // by some factor that can be adjusted to achieve the desired effect
    [SerializeField] float positionPitchFactor = -60f; 
    [SerializeField] float controlPitchFactor = -45f;
    [SerializeField] float positionYawFactor = 60f; 
    [SerializeField] float controlYawFactor = 25f;
    [SerializeField] float controlRollFactor = -35f;

    float xThrow, yThrow;

    void Start()
    {

    }

    void Update()
    {
        DroneMovement();
        DroneRotation();
    }

    void DroneMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * xSpeed * Time.deltaTime;

        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xClamp, xClamp);
        float newYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yClampMin, yClampMax);

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    void DroneRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor; // X rotation axis
        float yaw = transform.localPosition.x * positionYawFactor + xThrow * controlYawFactor; // Y rotation axis
        float roll = xThrow * controlRollFactor; // Z rotation axis
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
