using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PickUp_GP : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }



    void OnCollisionEnter(Collision col)
    {
        SCR_GhostController GhostController = col.gameObject.GetComponent<SCR_GhostController>();
        GhostController.GhostPowerEnergy += 50;
        Destroy(this.gameObject);
    }
}
//voordat alle changes worden uitgevoerd aan de var moeten ze eerst door een poort endan pas uitgevoerd