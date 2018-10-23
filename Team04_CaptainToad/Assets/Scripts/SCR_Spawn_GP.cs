using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Spawn_GP : MonoBehaviour
{
    bool _pickUpSpawned = false;
    public GameObject PREF_PickUp;
    GameObject _pickup;
    const int spawnTijd = 3;
    float _timer = 0;

	void Update ()
    {
        //Timer bijhouden voor de spawn snelheid te bepalen
        _timer += Time.deltaTime;

        //zoek midden van eigen object + eigen hoogte in de z ass is pickup position instantiate pickup
        if (_pickUpSpawned == false)
        {
            _pickUpSpawned = true;
            _pickup = Instantiate(PREF_PickUp, transform.position - new Vector3(0, -0.5f, 0), Quaternion.identity);
        }

        //Check object status & als er geen pickup is spawn dan pick up na spawnTijd sec
        if (_pickup == null && _timer >= spawnTijd)
        {
            _pickUpSpawned = false;
            _timer = 0;
        }     
    }
}
