using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FightUIManager : MonoBehaviour {
    public Canvas defeatPanel;
    public Canvas victoryPanel;
    public Canvas fightScene;
    bool afterFight = false;
    public bool inFight = false;
	// Use this for initialization
	void Start ()
    {
        inFight = gameObject.GetComponent<ShaftObject>().inFight;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(inFight)
        {
            fightScene.enabled = true;
        }
	}

    public void Defeat()
    {
        inFight = false;
        fightScene.enabled = false;
        SceneManager.LoadScene("UpgradeScene");
       


    }
    public void Victory()
    {
        fightScene.enabled = false;
        inFight = false;
        
        
    }
    public void InFight()
    {
        inFight = true;
    }

}
