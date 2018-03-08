using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FightUIManager : MonoBehaviour {
    public Canvas defeatPanel;
    public Canvas victoryPanel;
    public Canvas fightScene;
    bool afterFight = false;    
    PlayerScript myPlayerScript;
    public GameObject myPlayer;
	// Use this for initialization
	void Start ()
    {
        myPlayerScript = myPlayer.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(myPlayerScript.inFight)
        {
            fightScene.enabled = true;
            if(myPlayerScript.health <= 0)
            {
                Debug.Log("You died");
                Defeat();
            }
        }
	}

    public void Defeat()
    {
        myPlayerScript.inFight = false;
        fightScene.enabled = false;
        SceneManager.LoadScene("UpgradeScene");
    }
    public void Victory()
    {
        fightScene.enabled = false;
        myPlayerScript.bankedCurrency[0] += 1;
        myPlayerScript.Bank();
        myPlayerScript.inFight = false;
    }
   

}
