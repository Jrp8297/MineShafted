using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public int health;
    public int [] tempCurrency;
    public int [] bankedCurrency;
    public int armorStyle;
    public int armorTier;
    public int weaponStyle;
    public int weaponTier;
    public bool isActive;
    public float depth;
    Vector3 position;
    Vector3 velocity;



    // Use this for initialization
    void Start () {
        tempCurrency = new int[10];
        bankedCurrency = new int[10];
		
	}
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
        if (SystemInfo.supportsGyroscope)
        {
            velocity = new Vector3(Input.gyro.attitude.x * Time.deltaTime, 0, Input.gyro.attitude.z * Time.deltaTime);
        }
        else
        {

            if (Input.GetKey("left"))
            {
                velocity.x = -.2f;
            }
            if (Input.GetKey("right"))
            {
                velocity.x = .2f;
            }
            if (Input.GetKey("right") && Input.GetKey("left"))
            {
                velocity.x = 0;
            }
        }
        position += velocity;
        gameObject.transform.position = position;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x,0.1f,0.9f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        
    }
    void StoreData()
    {
        PlayerPrefs.SetInt("Health", health);
        for (int i = 0; i <= 9; i++)
        {
            PlayerPrefs.SetInt("Currency" +i, tempCurrency[i]);
        }
        for (int i = 0; i <= 9; i++)
        {
            PlayerPrefs.SetInt("Currency" + i, bankedCurrency[i]);
        }
        PlayerPrefs.SetInt("ArmourType", armorStyle);
        PlayerPrefs.SetInt("ArmourTier", armorTier);
        PlayerPrefs.SetInt("WeaponType", weaponStyle);
        PlayerPrefs.SetInt("WeaponTier", weaponTier);
        PlayerPrefs.Save();
    }
    void GetData()
    {
        PlayerPrefs.GetInt("Health", health);
        for (int i = 0; i <= 9; i++)
        {
            PlayerPrefs.GetInt("Currency" + i, tempCurrency[i]);
        }
        for (int i = 0; i <= 9; i++)
        {
            PlayerPrefs.GetInt("Currency" + i, bankedCurrency[i]);
        }
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
    
    void Bank()
    {
        for (int i = 0; i <= 9; i++)
        {
            bankedCurrency[i] += tempCurrency[i];
            tempCurrency[i] = 0;
        }
        StoreData();
    }


}
