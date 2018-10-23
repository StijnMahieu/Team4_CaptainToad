using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour {

    private Vector3 _moveDirection = new Vector3(0, 0, 1);
    private Vector3 _startPosition;

    [SerializeField]
    private float _movementSpeed;

    private float _maxBlockPosition = -1.8f;
    private float _minBlockPosition = -3.5f;

    private void Start()
    {
        _startPosition = this.transform.position;
    }
    void FixedUpdate ()
    {
        MovingBlocks();
	}

    private void MovingBlocks()
    {
        if (_startPosition.z == _minBlockPosition)
        {
            this.transform.Translate(_moveDirection * _movementSpeed * Time.deltaTime);
            if (this.transform.position.z >= _maxBlockPosition || this.transform.position.z <= _minBlockPosition)
            {
                _moveDirection = -_moveDirection;
            }
        }
        if (_startPosition.z == _maxBlockPosition)
        {
            this.transform.Translate(-_moveDirection * _movementSpeed * Time.deltaTime);
            if (this.transform.position.z >= _maxBlockPosition || this.transform.position.z <= _minBlockPosition)
            {
                _moveDirection = -_moveDirection;
            }
        }
    }
}
