﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SCR_GhostController : MonoBehaviour
{

    bool _ghostPowerON = false;
    public Material MAT_test;
    Color color;
    Collider[] colliders;
    SCR_CoinController CoinController;
    private float _ghostPowerEnergy = 200;

    public float GhostPowerEnergy
    {
        get
        {
            return _ghostPowerEnergy;
        }
        set
        {

            if (GhostPowerEnergy > 200)
            {
                _ghostPowerEnergy = 200;
                Debug.Log("Was te groot dus is verkleind");
            }
            else if (GhostPowerEnergy > 0)
            {
                _ghostPowerEnergy = value;
            }
            else
            {
                _ghostPowerEnergy = 0;
                GhostPower(false);
                Debug.Log("Was te klein dus is vergroot");
            }
        }
    }

    private void Start()
    {
        ////Eerst kleur van de editor opslaan en zorgen dat het begint vanaf opaque
        //color = MAT_test.color;
        //color.a = 1;
        //MAT_test.color = color;
        //CoinController = GameObject.FindWithTag("CoinController").GetComponent<SCR_CoinController>();
    }
    void Update()
    {
        //als spacebar wordt ingedrukt dan ghostpower activated
        if (Input.GetButton("Action"))
        {
            GhostPower(true);
        }
        else if (Input.GetButtonUp("Action"))
        {
            GhostPower(false);
        }
    }

    private void GhostPower(bool ghostPowerStatus)
    {
        if (ghostPowerStatus)//ghost mode ON
        {
            BlendMode(MAT_test, "Transparent");
            GhostPowerEnergy -= 0.5f;
            _ghostPowerON = true;
        }
        else//ghost mode OFF
        {
            _ghostPowerON = false;
            BlendMode(MAT_test, "Opaque");
        }

    }

    private void BlendMode(Material material, string mode, float fadingSpeed = 5, float fadingStop = 0.5f)
    {
        Color _color;

        switch (mode)
        {
            case "Opaque":
                _color = material.color;
                StartCoroutine(FadeOut(_color.a, 1f, 0.5f));
                break;

            case "Transparent":
                _color = material.color;
                StartCoroutine(FadeOut(_color.a, 0.25f, 0.5f));
                break;
        }
    }

    private IEnumerator FadeOut(float alphaStart, float alphaFinish, float time)
    {
        Color color;
        color = MAT_test.color;
        float elapsedTime = 0;
        color.a = alphaStart;

        while (elapsedTime < time)
        {
            color.a = Mathf.Lerp(color.a, alphaFinish, (elapsedTime / time));
            MAT_test.color = color;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Coin" || hit.gameObject.tag == "Gem")
        {        
            //CoinController.coinCount += 1;
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "BigCoin")
        {
            //CoinController.coinCount += 50;
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "GhostPowerEnergy")
        {
            SCR_GhostController GhostController = hit.gameObject.GetComponent<SCR_GhostController>();
            GhostPowerEnergy += 50;
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "Lava")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (hit.gameObject.tag == "Star")
        {
            SceneManager.LoadScene("LevelSelection");
        }

        //destructable met ghost power
        if (hit.gameObject.tag == "Destroyable" && _ghostPowerON)
        {
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "Torch" && _ghostPowerON)
        {
            hit.gameObject.GetComponent<Collider>().isTrigger = true;

        }
    }

   

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Torch" && _ghostPowerON == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }   

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Torch")
        {
            col.gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Torch" && _ghostPowerON)
        {
            SCR_Torch Torch = col.gameObject.GetComponent<SCR_Torch>();
            Torch._torchActivated = !Torch._torchActivated;
            Debug.Log(Torch._torchActivated);
        }
    }
}