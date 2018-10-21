using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualDebug : MonoBehaviour {
    
    public CharControl CharControl;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) AudioManager.Instance.PlayGemEffects();
        if (Input.GetKeyDown(KeyCode.U)) AudioManager.Instance.Play("UIFX6");
    }
    */

    void OnGUI()
    {
        
        GUILayout.BeginArea(new Rect(20, 20, 250, 670));
       
        
        GUILayout.Label("-------------- POS --------------");
        GUILayout.Label("Velocity: " + controller.velocity);
        GUILayout.Label("Move: " + CharControl.Move);
        GUILayout.Label("isGrounded: " + controller.isGrounded);
        GUILayout.Label("isGliding: " + CharControl.IsRunning);
        //GUILayout.Label("isCharging: " + CharControl.IsCharging);
        //GUILayout.Label("isBashing: " + CharControl.IsBashing);
        /*
        GUILayout.Label("-------------- STATS --------------");
        GUILayout.Label("Lives: " + GetComponent<Lives>().Amount());
        GUILayout.Label("Eggs: " + GetComponent<Eggs>().Amount());
        GUILayout.Label("Keys: " + GetComponent<Keys>().Amount());
        GUILayout.Label("Gems: " + GetComponent<Gems>().Amount());
        GUILayout.Label("");
        GUILayout.Label("");
        */
        GUILayout.Label("-------------- AXIS --------------");
        GUILayout.Label("Vertical: " + Input.GetAxis("Vertical"));
        GUILayout.Label("Horizontal: " + Input.GetAxis("Horizontal"));
        GUILayout.Label("Vertical_R: " + Input.GetAxis("Vertical_R"));
        GUILayout.Label("Horizontal_R: " + Input.GetAxis("Horizontal_R"));
        GUILayout.Label("Mouse X: " + Input.GetAxis("Mouse X"));
        GUILayout.Label("Mouse Y: " + Input.GetAxis("Mouse Y"));
        //GUILayout.Label("L2: " + Input.GetAxis("L2"));
        //GUILayout.Label("R2: " + Input.GetAxis("R2"));
        GUILayout.Label("");

        GUILayout.Label("------------- BUTTONS ------------");
        //GUILayout.Label("X: " + Input.GetButton("Run"));
        GUILayout.Label("□: " + Input.GetButton("Throw"));
        GUILayout.Label("O: " + Input.GetButton("Run"));
        GUILayout.Label("∆: " + Input.GetButton("Zoom"));
        GUILayout.Label("Start: " + Input.GetButton("Start"));
        GUILayout.Label("Select: " + Input.GetButton("Select"));
        
        GUILayout.Label("L1: " + Input.GetButton("L1"));
        GUILayout.Label("R1: " + Input.GetButton("R1"));
        GUILayout.Label("Left Analog Button: " + Input.GetButton("LeftAnalogButton"));
        GUILayout.Label("Right Analog Button: " + Input.GetButton("RightAnalogButton"));
        GUILayout.EndArea();
        
    }
}
