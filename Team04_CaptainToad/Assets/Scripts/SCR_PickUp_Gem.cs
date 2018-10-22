using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PickUp_Gem : MonoBehaviour
{
    SCR_GemController GemController;

    private void Start()
    {
        GemController = GameObject.FindWithTag("GemController").GetComponent<SCR_GemController>();
    }
    //GEM PICK UP
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision col)
    {
        GemController.gemCount += 1;
        Destroy(this.gameObject);
    } 
}
