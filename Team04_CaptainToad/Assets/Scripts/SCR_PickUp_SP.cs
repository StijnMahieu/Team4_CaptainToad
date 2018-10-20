using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PickUp_SP : MonoBehaviour
{
    //STAR POINTS PICK UP
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision col)
    {
        SCR_StarController StarController = GameObject.FindWithTag("StarController").GetComponent<SCR_StarController>();
        StarController.starCount += 1;
        Destroy(this.gameObject);
    } 
}
