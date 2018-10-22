using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PickUp_SC : MonoBehaviour
{
    SCR_CoinController CoinController;
    private void Start()
    {
        CoinController = GameObject.FindWithTag("CoinController").GetComponent<SCR_CoinController>();
    }

    //SMALL COIN PICK UP
    void Update()
    {     
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision col)
    {
    
        CoinController.coinCount += 1;
        Debug.Log(CoinController.coinCount);
        Destroy(this.gameObject);
     
    }
}
