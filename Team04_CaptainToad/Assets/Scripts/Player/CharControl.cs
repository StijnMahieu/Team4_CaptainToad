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

    // Private variables
    private float movementSpeed = 7.5f;
    private float gravity = 10f;
    private Vector3 impact = Vector3.zero;
    private float activeSpeed;
    private float fallingMultiplier;
    private CharacterController controller;

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
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            Move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetButton("Run"))
            {
                movementSpeed *= 1.5f;
            }

            Move *= movementSpeed;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the Move is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        Move = new Vector3(Move.x, (Move.y - gravity * Time.deltaTime), Move.z);

        // Move the controller
        controller.Move(Move * Time.deltaTime);

        /*
        if (Move != Vector3.zero)
            controller.transform.forward = new Vector3(Move.x, 0f, Move.z);

        if (Move != Vector3.zero)
            controller.transform.rotation = Quaternion.LookRotation(Move);
        */
    }

    public void AddImpact(Vector3 dir, float force) {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
        fallingMultiplier = .5f;
    }

    public void TargetRotation(Quaternion target) {
        // Keeps character aligned with forward camera axis
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * speedRotation); //lerp rotation to given rotation
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
