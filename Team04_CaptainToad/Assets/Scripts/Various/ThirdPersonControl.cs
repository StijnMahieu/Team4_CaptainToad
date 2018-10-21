using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControl : MonoBehaviour {

    public CharControl CharControl;
    public Vector2 LimitY = new Vector2(5, 85);
    public float SpeedRotate = 180;
    public float Speed = 5f;
    public Transform CameraY;
    private CharacterController _controller;

    public Transform Target;

    private float _yRotation = 0.0f;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessCameraMovements();
    }

    void ProcessCameraMovements()
    {
        
        // Handles right joystick input
        CameraY.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal_R"), 0) * SpeedRotate * Time.deltaTime);

        /*
        _yRotation += Input.GetAxis("Vertical_R") * SpeedRotate * Time.deltaTime;
        _yRotation = Mathf.Clamp(_yRotation, LimitY.x, LimitY.y);
        CameraY.eulerAngles = new Vector3(_yRotation, CameraY.eulerAngles.y, CameraY.eulerAngles.z);
        */


        CameraY.transform.LookAt(Target);
        //CameraY.transform.Translate(Vector3.right * Time.deltaTime);
        
    }
}
