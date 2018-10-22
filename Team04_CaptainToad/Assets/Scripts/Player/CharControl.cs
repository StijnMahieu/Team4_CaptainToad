using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {

    #region Variables

    // readonly variables
    private readonly float speedRotation = 10;
    private readonly float mass = 3.0F; // defines the character mass
    private readonly float movementSpeedDefault = 4f;
    private readonly float activeSpeed;
    private readonly float gravity = 20f;
    private readonly float fallingMultiplier;

    // Private variables
    private Vector3 impact = Vector3.zero;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public float jumpSpeed = 8.0F;

    // Public variables
    public CameraControlsPlayer CamControls;

    #endregion

    #region Properties

    public bool IsRunning { get; private set; }
    public Vector3 Move { get; private set; }

    #endregion

    #region Methods

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {

        float _speed;
        
        // Check if we are touching the ground first
        if (controller.isGrounded)
        {
            // We want movement relative to selected camera
            Camera _c = CamControls.SelectedCam;

            // Camera forward and right vectors:
            Vector3 _forward = _c.transform.forward;
            Vector3 _right = _c.transform.right;

            // Project forward and right vectors on the horizontal plane (y = 0)
            _forward.y = 0f;
            _right.y = 0f;
            _forward.Normalize();
            _right.Normalize();

            // This is the direction in the world space we want to move:
            moveDirection = _forward * Input.GetAxis("Vertical") + _right * Input.GetAxis("Horizontal");

            // Add speed if "Run"-button is pressed.
            _speed = Input.GetButton("Run") ? movementSpeedDefault * 1.5f : movementSpeedDefault;

            // Multiply movement by current speed modifier.
            moveDirection *= _speed;

            // 
            if (moveDirection != Vector3.zero)
                transform.forward = new Vector3(moveDirection.x, 0f, moveDirection.z);
        }

        // Add gravity to the movement. (Use deltatime because ^2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character controller
        controller.Move(moveDirection * Time.deltaTime);

        // if (Input.GetButton("Action")) DoAction();
    }

    #endregion
}
