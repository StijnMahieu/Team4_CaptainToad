using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour {

    #region Variables

    // Public variables
    public static CharControl Instance;
    public GameObject CameraY;

    // readonly variables
    private readonly float speedRotation = 10;
    private readonly float mass = 3.0F; // defines the character mass
    private readonly float movementSpeedDefault = 6f;
    private readonly float activeSpeed;
    private readonly float gravity = 20f;
    private readonly float fallingMultiplier;

    // Private variables
    private Vector3 impact = Vector3.zero;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public float jumpSpeed = 8.0F;

    #endregion

    #region Properties

    public bool IsRunning { get; private set; }
    public Vector3 Move { get; private set; }

    #endregion

    #region Methods

    void Start()
    {
        Instance = this;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float _speed;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            _speed = Input.GetButton("Run") ? movementSpeedDefault * 1.5f : movementSpeedDefault;
            moveDirection *= _speed;
            /*
            if (Input.GetButton("Action"))
                moveDirection.y = jumpSpeed;
            */

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //if (moveDirection != Vector3.zero) controller.transform.right = new Vector3(moveDirection.x, 0f, moveDirection.z);
    }

    private Camera GetPlayerCam()
    {
        Camera _c = null;
        foreach (Camera c in Camera.allCameras)
        {
            if (c.name == "PlayerCam") _c = c;
        }
        if (_c == null) _c = Camera.main;
        //Debug.Log("Active camera: " + _c);
        return _c;
    }

    #endregion
}
