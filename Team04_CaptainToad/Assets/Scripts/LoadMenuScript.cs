﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuScript : MonoBehaviour {

    public bool _level1Completed = false;
    public bool _level2Completed = false;
    public bool _level3Completed = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    private void LoadLevel2()
    {
        if (_level2Completed == true)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void LoadLevel3()
    {
        if (_level2Completed == true)
        {
            SceneManager.LoadScene(3);
        }
    }
}
