using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeObject : MonoBehaviour {
    public Sprite [] objectsToDisplay;
    Image myImage;    
    
    public int storeSlot;
    

	// Use this for initialization
	void Start () {

        UpdateIcon();
	}

    public void UpgradeItem()
    {
        switch (storeSlot)
        {
            case 2://armor
                //add if statement later
                Debug.Log("armor upgrade called");
                PlayerPrefs.SetInt("ArmourTier", PlayerPrefs.GetInt("ArmourTier") + 1);
                PlayerPrefs.Save();
                UpdateIcon();
                break;
            case 1://Weapon
                //add if statement later
                Debug.Log("Weapon upgrade Called");
                PlayerPrefs.SetInt("WeaponTier", PlayerPrefs.GetInt("WeaponTier") + 1);
                PlayerPrefs.Save();
                UpdateIcon();
                break;
            default:

                break;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateIcon()
    {
        myImage = gameObject.GetComponent<Image>();
        switch (storeSlot)
        {
            case 1:                
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("WeaponTier")];               
                break;
            case 2:
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("ArmourTier")];
                break;
            default:
                break;
    }
    }
}
