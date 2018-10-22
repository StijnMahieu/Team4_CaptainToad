using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlsPlayer : MonoBehaviour {

    #region Variables

    // Public variables
    public Vector2 LimitY = new Vector2(-90, 90);
    public float SpeedRotate = 90;
    public float Speed = 5f;

    // Wide cam
    public Camera CameraWide;
    public Transform CameraWideY;
    public Transform CameraWideHolder;

    // Fixed cam
    public Camera CameraFixed;
    public Transform CameraFixedY;
    public Transform CameraFixedHolder;
    public Transform Target;

    // Private variables
    private float _yRotation = 0.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Zoom")) SwitchCameraFocus();

        ProcessCameraMovements();
    }

    private void SwitchCameraFocus()
    {
        bool _toSet = (SelectedCam.Equals(CameraWide));
        CameraWideHolder.gameObject.SetActive(!_toSet);
        CameraFixedHolder.gameObject.SetActive(_toSet);

        //Debug.Log("Switched cam to: " + SelectedCam);
        SelectedCam = (_toSet) ? CameraFixed : CameraWide;
    }

    void ProcessCameraMovements()
    {
        //CameraHolder.transform.position = Vector3.Slerp(controller.transform.position, CameraHolder.transform.position, Time.deltaTime);

        // Handles right joystick input
        CameraWideY.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal_R"), 0) * SpeedRotate * Time.deltaTime);

        /*
        _yRotation += Input.GetAxis("Vertical_R") * SpeedRotate * Time.deltaTime;
        _yRotation = Mathf.Clamp(_yRotation, LimitY.x, LimitY.y);
        CameraY.eulerAngles = new Vector3(_yRotation, CameraY.eulerAngles.y, CameraY.eulerAngles.z);
        */

        Vector3 _target = (SelectedCam.Equals(CameraFixed)) ? Target.transform.position: (Vector3.zero);
        //Camera.transform.Translate(Vector3.forward * Time.deltaTime);

        SelectedCam.transform.LookAt(_target);
    }

    #endregion
}
