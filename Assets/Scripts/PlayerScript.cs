using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public int health;
    public int tempCurrency;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StoreData()
    {
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("Copper", tempCurrency);
    }
}
