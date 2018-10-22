using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControl : MonoBehaviour {

    public CharControl CharControl;
    public Vector2 LimitY = new Vector2(-90, 90);
    public float SpeedRotate = 180;
    public float Speed = 5f;
    public Transform CameraY;
    public Transform Camera;
    public Transform CameraHolder;
    private CharacterController controller;

    public Transform Target;

    private float _yRotation = 0.0f;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessCameraMovements();
    }

    void ProcessCameraMovements()
    {
        CameraHolder.transform.position =  Vector3.Slerp(controller.transform.position, CameraHolder.transform.position, Time.deltaTime);

        // Handles right joystick input
        CameraY.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal_R"), 0) * SpeedRotate * Time.deltaTime);

        /*
        _yRotation += Input.GetAxis("Vertical_R") * SpeedRotate * Time.deltaTime;
        _yRotation = Mathf.Clamp(_yRotation, LimitY.x, LimitY.y);
        CameraY.eulerAngles = new Vector3(_yRotation, CameraY.eulerAngles.y, CameraY.eulerAngles.z);
        */

        Camera.transform.LookAt(Target);
        //Camera.transform.Translate(Vector3.forward * Time.deltaTime);
        
    }
}
