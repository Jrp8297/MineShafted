using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDObject : MonoBehaviour {
    public int index;
    public Text toDisplay;

	// Use this for initialization
	void Start () {
        toDisplay = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //if(dirty)
        toDisplay.text = PlayerPrefs.GetInt("BankedCurrency" + index).ToString();
		
	}
}
