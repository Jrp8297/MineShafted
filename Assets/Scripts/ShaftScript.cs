﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftScript : MonoBehaviour {

    public List<GameObject> OrePrefabList;
    public List<GameObject> MonsterPrefabList;
    public GameObject Wall;
    public int Level;
    public GameObject player;
    int MonsterListSize, OreListSize;
    bool LastOre = false;
    bool Wall1 = false;
    bool Wall2 = false;
    bool Wall3 = false;
    Vector3 spawnPosition;


    // Use this for initialization
    void Start () {
        MonsterListSize = MonsterPrefabList.Count;
        OreListSize = OrePrefabList.Count;
        spawnPosition = Camera.main.ViewportToWorldPoint( new Vector3(0, 0, 1));
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.childCount < 3 * Level) 
        {//Check to instatiate new objects at the bottom of the screen;
            if (LastOre)
            {//if we spawned an Ore last, Spawn a Monster
                spawnPosition = Camera.main.WorldToViewportPoint(spawnPosition);
                spawnPosition.x = Random.Range(0.1f, 0.9f);
                spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
                GameObject temp = Instantiate(MonsterPrefabList[Random.Range(0, (Level * 3)-1)], spawnPosition, Quaternion.identity, gameObject.transform);
                temp.GetComponent<ShaftObject>().player = player.GetComponent<PlayerScript>();
                LastOre = false;
            }
            else if (!Wall1 && PlayerPrefs.GetFloat("TempDepth") >= 10.0f)
            {// if we hit a certain point, spawn a wall
                spawnPosition = Camera.main.WorldToViewportPoint(spawnPosition);
                spawnPosition.x = 0.5f;
                spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
                GameObject temp = Instantiate(Wall, spawnPosition, Quaternion.identity, gameObject.transform);
                temp.GetComponent<ShaftObject>().player = player.GetComponent<PlayerScript>();
                Wall1 = true;
            }
            else if (!Wall2 && PlayerPrefs.GetFloat("TempDepth") >= 30.0f)
            {// if we hit a certain point, spawn a wall
                spawnPosition = Camera.main.WorldToViewportPoint(spawnPosition);
                spawnPosition.x = 0.5f;
                spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
                GameObject temp = Instantiate(Wall, spawnPosition, Quaternion.identity, gameObject.transform);
                temp.GetComponent<ShaftObject>().player = player.GetComponent<PlayerScript>();
                Wall2 = true;
            }
            else if (!Wall3 && PlayerPrefs.GetFloat("TempDepth") >= 60.0f)
            {// if we hit a certain point, spawn a wall
                spawnPosition = Camera.main.WorldToViewportPoint(spawnPosition);
                spawnPosition.x = 0.5f;
                spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
                GameObject temp = Instantiate(Wall, spawnPosition, Quaternion.identity, gameObject.transform);
                temp.GetComponent<ShaftObject>().player = player.GetComponent<PlayerScript>();
                Wall3 = true;
            }
            else
            {//If we spawned a monster Last, Spawn an Ore
                spawnPosition = Camera.main.WorldToViewportPoint(spawnPosition);
                spawnPosition.x = Random.Range(0.1f, 0.9f);
                spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
                GameObject temp = Instantiate(OrePrefabList[Random.Range(0, (Level * 3 - 1))], spawnPosition, Quaternion.identity, gameObject.transform);
                temp.GetComponent<ShaftObject>().player = player.GetComponent<PlayerScript>();
                LastOre = true;
            }

        }
		
	}
}
