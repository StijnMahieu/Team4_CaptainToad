using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PickUp_BC : MonoBehaviour
{
    //BIG COIN PICK UP
    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision col)
    {
        SCR_CoinController CoinController = GameObject.FindWithTag("CoinController").GetComponent<SCR_CoinController>();
        CoinController.coinCount += 10;
        Debug.Log(CoinController.coinCount);
        Destroy(this.gameObject);
  
    }
}
