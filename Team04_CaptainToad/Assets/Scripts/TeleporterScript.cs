using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour {

    [SerializeField]
    private CharacterController _playerToad;

    private Vector3 _TeleporterBasePosition;
    private Vector3 _TeleporterTopPosition;

    [SerializeField]
    private GameObject _baseTeleporter;
    [SerializeField]
    private GameObject _topTeleporter;

    [SerializeField]
    private float _teleportTimer;

    private bool _teleportCoolDown = false;

    private Vector3 _movement;
    // Use this for initialization
    void Start ()
    {
        //store teleporterpositions in 2 seperate vectors
        _TeleporterBasePosition = _baseTeleporter.transform.position;
        _TeleporterTopPosition = _topTeleporter.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //testcode
        _movement = new Vector3(Input.GetAxis("Horizontal"), -500, Input.GetAxis("Vertical"))*Time.deltaTime;
        PlayerMovement();
        //testcode

        if (_teleportCoolDown == true)
        {
            _teleportTimer -= Time.deltaTime;
            Debug.Log(_teleportTimer);
            if (_teleportTimer <= 0)
            {
                _teleportCoolDown = false;
            }
        }
    }

    //testcode
    private void PlayerMovement()
    {
        _playerToad.Move(_movement);
    }
    //testcode

    private void OnTriggerStay(Collider _collision)
    {
        if (_collision.gameObject.tag == "TeleporterBase" && _teleportCoolDown == false)
        {
            TeleportUp();
            _teleportCoolDown = true;
            _teleportTimer = 5.0f;
        }
        if (_collision.gameObject.tag == "TeleporterTop" && _teleportCoolDown == false)
        {
            TeleportDown();
            _teleportCoolDown = true;
            _teleportTimer = 5.0f;
        }
    }
    //change between teleporters
    private void TeleportUp()
    {
        _playerToad.transform.position = _TeleporterTopPosition;
    }
    private void TeleportDown()
    {
        _playerToad.transform.position = _TeleporterBasePosition;
    }
}
