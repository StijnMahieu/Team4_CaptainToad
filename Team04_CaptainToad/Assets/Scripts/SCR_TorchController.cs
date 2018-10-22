using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TorchController : MonoBehaviour
{
    int _childCount;
    public int torchCount = 0;
    public bool switchPowerON = false;

    void Start ()
    {
        _childCount = this.transform.childCount-1;
    }
	
	void Update ()
    {
        //Torch controller houd stand bij van aantal torches die aan moeten zijn
        if(torchCount == _childCount && switchPowerON == false)
        {
            Debug.Log("U moeder");
            switchPowerON = true;         

        }
        else if(torchCount != _childCount && switchPowerON)
        {
            Debug.Log("sssssssssssssssss moeder");
            switchPowerON = false;
        }
    }

  
}
