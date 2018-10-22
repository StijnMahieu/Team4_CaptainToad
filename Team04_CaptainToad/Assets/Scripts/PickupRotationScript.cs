using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotationScript : MonoBehaviour {

    private float _rotationY = 2;

	// Update is called once per frame
	void Update ()
    {
        transform.eulerAngles += new Vector3(0, _rotationY, 0);
    }
}
