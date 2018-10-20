using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    [SerializeField]
    private CharacterController _pumpkinToad;

    private Vector3 _movement;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        _pumpkinToad.Move(_movement);
    }

}
