using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In meters per second")][SerializeField] float xSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        // Debug.Log(xThrow);
        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        Debug.Log(xOffsetThisFrame);
    }
}
