using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlsPlayer : MonoBehaviour {

    #region Variables

    // Public variables
    public Vector2 LimitY = new Vector2(-90, 90);
    private CharacterController controller;
    public float SpeedRotate = 90;
    public float Speed = 5f;
    public Transform FocusPoint;
    public Transform CameraY;
    public Camera CameraWide; // Wide cam
    public Camera CameraFixed; // Fixed cam
    public Transform Target;

    // Private variables
    private float yRotation = 0.0f;

    #endregion

    #region Properties

    public Camera SelectedCam { get; private set; }

    #endregion

    #region Methods

    // Use this for initialization
    void Start()
    {
        SelectedCam = CameraWide;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Zoom")) SwitchCameraFocus(SelectedCam.Equals(CameraWide));

        ProcessCameraMovements();
    }

    private void SwitchCameraFocus(bool _toSet)
    {
        // Flip active camera
        CameraWide.gameObject.SetActive(!_toSet);
        CameraFixed.gameObject.SetActive(_toSet);

        // Set selected cam
        SelectedCam = (_toSet) ? CameraFixed : CameraWide;
    }

    void ProcessCameraMovements()
    {

        // Handles right joystick input
        CameraY.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal_R"), 0) * SpeedRotate * Time.deltaTime);
        
        if (Input.GetAxis("Vertical_R") != 0)
        {
            CameraY.transform.Rotate(new Vector3(Input.GetAxis("Vertical_R"), 0, 0), Space.Self);
            Vector3 currentRotation = CameraY.transform.localRotation.eulerAngles;

            // Clamp not working yet.
            //currentRotation.x = Mathf.Clamp(currentRotation.x, LimitY.x, LimitY.y);
            CameraY.transform.localRotation = Quaternion.Euler(currentRotation);
        }
        
        // Determine focus based on active cam
        Vector3 _target = (SelectedCam.Equals(CameraFixed)) ? Target.transform.position: FocusPoint.position;

        // Focus on target
        SelectedCam.transform.LookAt(_target);
    }

    #endregion
}
