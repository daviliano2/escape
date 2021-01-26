using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters per second")] [SerializeField] float xSpeed = 4f;
    [SerializeField] float rotationZSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -0.35f, 0.35f);

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);

        float zThrow = CrossPlatformInputManager.GetAxis("Roll");
        // float zOffset = zThrow * rotationZSpeed * Time.deltaTime;
        float zOffset =  Mathf.Clamp(zThrow * rotationZSpeed * Time.deltaTime, -90f, 90f);
        // float newZRotation = Mathf.Clamp(transform.localRotation.z + zOffset, -90f, 90f);

        transform.Rotate(transform.localRotation.x, transform.localRotation.y, zOffset);
    }
}
