using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public int health;
    public int tempCurrency;
    public int armorStyle;
    public int armorTier;
    public int weaponStyle;
    public int weaponTier;
    public bool isActive;
    Vector3 position;
    Vector3 velocity;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
        if (SystemInfo.supportsGyroscope)
        {
            velocity = new Vector3(Input.gyro.attitude.x * Time.deltaTime, 0, Input.gyro.attitude.z * Time.deltaTime);
        }
        if(Input.GetKey("left"))
        {
            velocity.x = .05f;
        }
        else if (Input.GetKey("right"))
        {
            velocity.x = -.05f;
        }

        position += velocity;
        gameObject.transform.position = position;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        
    }

    void StoreData()
    {
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("Copper", tempCurrency);
        PlayerPrefs.SetInt("ArmourType", armorStyle);
        PlayerPrefs.SetInt("ArmourTier", armorTier);
        PlayerPrefs.SetInt("WeaponType", weaponStyle);
        PlayerPrefs.SetInt("WeaponTier", weaponTier);
        PlayerPrefs.Save();
    }

    void GetData()
    {
        PlayerPrefs.GetInt("Health", health);
        PlayerPrefs.GetInt("Copper", tempCurrency);
        PlayerPrefs.GetInt("ArmourType", armorStyle);
        PlayerPrefs.GetInt("ArmourTier", armorTier);
        PlayerPrefs.GetInt("WeaponType", weaponStyle);
        PlayerPrefs.GetInt("WeaponTier", weaponTier);
    }

    void ResetData()
    {
        PlayerPrefs.SetInt("Health", 10);
        PlayerPrefs.SetInt("Copper", 0);
        PlayerPrefs.SetInt("ArmourType", 0);
        PlayerPrefs.SetInt("ArmourTier", 0);
        PlayerPrefs.SetInt("WeaponType", 0);
        PlayerPrefs.SetInt("WeaponTier", 0);
        PlayerPrefs.Save();
    }
}
