using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TriggerTest : MonoBehaviour
{
    SCR_TorchController TorchController;
    // Use this for initialization
    void Start ()
    {
        TorchController = SCR_Helper.FindParentWithTag(this.gameObject,"TorchController").GetComponent<SCR_TorchController>();
    }  
	
	// Update is called once per frame
	void Update ()
    {
        if(TorchController.switchPowerON)
        {
            Debug.Log("U moeder");
        }
        else
        {
            Debug.Log("Niet u moeder");
        }

    }
}
