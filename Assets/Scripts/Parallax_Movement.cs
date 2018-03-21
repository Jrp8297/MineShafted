using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Movement : MonoBehaviour {

    Vector3 newPos;
    Vector3 newScale;
    public Vector3 speed;

    float scoreMod;
    float time;
    
	// Use this for initialization
	void Start () {
        // start by setting the position and scale
        // regardless, recommend 2 sprites: one at -12.5 x 0 y, the other at 12.5 x 0 y
        newPos = gameObject.transform.position;
        newScale.x = (3.2f*.626f);
        newScale.y = (1.7f * .626f);
        newScale.z = 1.0f;
        gameObject.transform.localScale = newScale;
        scoreMod = 5;
        time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        // move the sprite down; currently hard coded but can be adjusted for speed
        time += Time.deltaTime;
        scoreMod = 5;
        //if (scoreMod < 1.0f) { scoreMod = 1.0f; }
        newPos = gameObject.transform.position;
		newPos.y -= speed.y * scoreMod * Time.deltaTime;
        // checks if the sprite is outside the camera; yes, hard coded for now until I can figure out the right command
        // to check whether the camera can see it
        if(newPos.y < -25.0f){
            newPos.y = 25.0f;
        }
        gameObject.transform.position = newPos;
    }
}
