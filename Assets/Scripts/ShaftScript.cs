using System.Collections;
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
    float nextWall = 20;
    Vector3 spawnPosition;
    float spawnTimer;
    float tempTime;


    // Use this for initialization
    void Start () {
        MonsterListSize = MonsterPrefabList.Count;
        OreListSize = OrePrefabList.Count;
        spawnPosition = Camera.main.ViewportToWorldPoint( new Vector3(0, 0, 1));
        spawnTimer = 0.0f;
        tempTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        tempTime += Time.deltaTime;
        if (gameObject.transform.childCount < 3 * Level && tempTime >= spawnTimer) 
        {//Check to instatiate new objects at the bottom of the screen;
            if (LastOre)
            {//if we spawned an Ore last, Spawn a Monster
                spawnPosition = Camera.main.WorldToViewportPoint(spawnPosition);
                spawnPosition.x = Random.Range(0.1f, 0.9f);
                spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
                GameObject temp = Instantiate(MonsterPrefabList[Random.Range(0, (Level * 3))], spawnPosition, Quaternion.identity, gameObject.transform);
                temp.GetComponent<ShaftObject>().player = player.GetComponent<PlayerScript>();
                LastOre = false;
                spawnTimer = Random.Range(0.25f, 1.0f);
                tempTime = 0.0f;
            }
            else if (nextWall <= PlayerPrefs.GetFloat("TempDepth"))
            {//If where the next wall should spawn is less than the players position
                spawnPosition = Camera.main.WorldToViewportPoint(spawnPosition);
                spawnPosition.x = 0.5f;
                spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
                GameObject temp = Instantiate(Wall, spawnPosition, Quaternion.identity, gameObject.transform);
                temp.GetComponent<ShaftObject>().player = player.GetComponent<PlayerScript>();
                temp.GetComponent<ShaftObject>().manager = gameObject.GetComponent<ShaftScript>();
                nextWall += (nextWall + (nextWall / 2));
                spawnTimer = Random.Range(1.0f, 2.0f);
                tempTime = 0.0f;
            }           
            else
            {//If we spawned a monster Last, Spawn an Ore
                spawnPosition = Camera.main.WorldToViewportPoint(spawnPosition);
                spawnPosition.x = Random.Range(0.1f, 0.9f);
                spawnPosition = Camera.main.ViewportToWorldPoint(spawnPosition);
                GameObject temp = Instantiate(OrePrefabList[Random.Range(0, (Level * 3))], spawnPosition, Quaternion.identity, gameObject.transform);
                temp.GetComponent<ShaftObject>().player = player.GetComponent<PlayerScript>();
                temp.GetComponent<SpriteRenderer>().sortingOrder = -1;
                LastOre = true;
                spawnTimer = Random.Range(0.25f, 1.0f);
                tempTime = 0.0f;
            }

        }
		
	}
}
