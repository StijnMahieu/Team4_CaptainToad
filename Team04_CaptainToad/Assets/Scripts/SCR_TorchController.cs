using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TorchController : MonoBehaviour
{
    int _childCount;
    public int torchCount = 0;
    public bool switchPowerON = false;
    public GameObject PREF_TriggerObject;
    GameObject TriggerObject;

    void Start ()
    {
        _childCount = this.transform.childCount;
    }
	
	void Update ()
    {
        //Torch controller houd stand bij van aantal torches die aan moeten zijn
        if(torchCount == _childCount && switchPowerON == false)
        {
            //Activeer object dat moet geactiveerd worden
            switchPowerON = true;         
            TriggerObject = Instantiate(PREF_TriggerObject, transform.position, Quaternion.identity);
        }
        else if(torchCount != _childCount)
        {
            switchPowerON = false;
            if (TriggerObject != null)
            {
                Destroy(TriggerObject);
            }
        }
	}
}
