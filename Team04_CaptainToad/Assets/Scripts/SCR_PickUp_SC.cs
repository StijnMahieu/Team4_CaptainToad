using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PickUp_SC : MonoBehaviour
{
    SCR_CoinController CoinController;
    private void Start()
    {
   
    }

    //SMALL COIN PICK UP
    void Update()
    {     
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision col)
    {
    
     
    }
}
