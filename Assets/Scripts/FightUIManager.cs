﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FightUIManager : MonoBehaviour {
    public Canvas defeatPanel;
    public Canvas victoryPanel;
    bool afterFight = false;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void Defeat()
    {
        SceneManager.LoadScene("UpgradeScene");
    }
    public void Victory()
    {
        SceneManager.LoadScene("ShaftScene");
    }
}