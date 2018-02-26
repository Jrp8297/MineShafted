using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftObject : MonoBehaviour {
    public bool isOre;
    int tier =1;
    GameManager manager;
    PlayerScript player;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOre)
        {
            manager.SwitchToFight();
        }
        else
        {
            player.tempCurrency += (1 * tier);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
