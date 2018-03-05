using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDObject : MonoBehaviour {
    public int index;
    public Text toDisplay;
    public PlayerScript player = null;

	// Use this for initialization
	void Start () {
        toDisplay = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //if(dirty)
        if (player == null)
        {
            toDisplay.text = PlayerPrefs.GetInt("BankedCurrency" + index).ToString();
        }
        else
        {
            toDisplay.text = PlayerPrefs.GetInt("BankedCurrency" + index).ToString() + " + " +  player.tempCurrency[index].ToString();
        }
	}
}
