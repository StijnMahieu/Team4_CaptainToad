using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelRotationScript : MonoBehaviour
{
    private float _turningDegrees = 0;

    [SerializeField]
    private float _rotationSpeed;
    private bool _isNinety = false;
    private bool _isOneEighty = false;
    private bool _istTwoSeventy = false;
    private bool _isTurning = false;

    [SerializeField]
    private float _timer = 3.0f;

    void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            _isTurning = true;
            RotateObject();
        }
    }

    private void RotateObject()
    {
        if(_isTurning == true)
        {
            _turningDegrees += _rotationSpeed;

            if(_turningDegrees >= 90 && _isNinety == false)
            {
                _turningDegrees = 90;
                _isTurning = false;
                _isNinety = true;
                _timer = 3.0f;
            }

            if (_turningDegrees >= 180 && _isOneEighty == false)
            {
                _turningDegrees = 180;
                _isTurning = false;
                _isOneEighty = true;
                _timer = 3.0f;
            }

            if (_turningDegrees >= 270 && _istTwoSeventy == false)
            {
                _turningDegrees = 270;
                _isTurning = false;
                _istTwoSeventy = true;
                _timer = 3.0f;
            }

            if (_turningDegrees >= 360)
            {
                _isTurning = false;
                _turningDegrees = 0;

                _isNinety = false;
                _isOneEighty = false;
                _istTwoSeventy = false;
                _timer = 3.0f;
            }

            this.transform.eulerAngles = new Vector3(0, _turningDegrees, 0);
        }
    }
}
