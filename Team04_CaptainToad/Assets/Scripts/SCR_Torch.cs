using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Torch : MonoBehaviour
{
    public bool _torchActivated = false;
    ParticleSystem _fireParticles;
    bool _torchInAnimation = false;
    SCR_TorchController TorchController;
    void Start ()
    {
       _fireParticles = this.GetComponent<ParticleSystem>();
       TorchController = gameObject.GetComponentInParent<SCR_TorchController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_torchActivated && _torchInAnimation == false)
        {
            _torchInAnimation = true;
            _fireParticles.Play();
            //Als de torch wordt geactiveerd dan geef parent controller +1 tot doel wordt bereikt            
            TorchController.torchCount += 1;     
        }
        else if (_torchActivated == false && _torchInAnimation == true)
        {
            _torchInAnimation = false;
            _fireParticles.Stop();
            //De Torch wordt weer uitgeschakeld
            TorchController.torchCount -= 1;        
        }


    }
}
