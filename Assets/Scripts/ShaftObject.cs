﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftObject : MonoBehaviour {
    public bool isOre;
    int tier =1;
    public GameManager manager;
    public PlayerScript player;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
        if (!isOre)
        {
            manager.SwitchToFight();
        }
        else
        {
            player.tempCurrency += (1 * tier);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 newPos = gameObject.transform.position;
        newPos.y += 1 * Time.deltaTime;
        gameObject.transform.position = newPos;

    }
}
