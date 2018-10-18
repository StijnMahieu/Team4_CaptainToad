using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour {

    private Vector3 _moveDirection = new Vector3(1, 0, 0);
    private Vector3 _startPosition;

    [SerializeField]
    private float _movementSpeed;

    private float _minBlockPosition = 1.8f;
    private float _maxBlockPosition = 3.5f;

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
        if (_startPosition.x == _minBlockPosition)
        {
            this.transform.Translate(_moveDirection * _movementSpeed * Time.deltaTime);
            if (this.transform.position.x >= _maxBlockPosition || this.transform.position.x <= _minBlockPosition)
            {
                _moveDirection = -_moveDirection;
            }
        }
        if (_startPosition.x == _maxBlockPosition)
        {
            this.transform.Translate(-_moveDirection * _movementSpeed * Time.deltaTime);
            if (this.transform.position.x >= _maxBlockPosition || this.transform.position.x <= _minBlockPosition)
            {
                _moveDirection = -_moveDirection;
            }
        }
    }
}
