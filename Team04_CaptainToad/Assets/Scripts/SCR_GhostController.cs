using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SCR_GhostController : MonoBehaviour
{

    bool _ghostPowerON = false;
    public Material MAT_test;
    Color color;
    Collider[] colliders;

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
        //Eerst kleur van de editor opslaan en zorgen dat het begint vanaf opaque
        color = MAT_test.color;
        color.a = 1;
        MAT_test.color = color;

    }
    void Update()
    {
        //als spacebar wordt ingedrukt dan ghostpower activated
        if (Input.GetKey("space"))
        {
            GhostPower(true);
        }
        else if (Input.GetKeyUp("space"))
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

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Torch" && _ghostPowerON)
        {
            col.gameObject.GetComponent<Collider>().isTrigger = true;
           
        }

        //destructable met ghost power
        if (col.gameObject.tag == "Destroyable" && _ghostPowerON)
        {
            Destroy(col.gameObject);
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