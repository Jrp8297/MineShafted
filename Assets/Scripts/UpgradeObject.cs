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
                if (PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("ArmourTier") + 1)) >= 10)
                {
                    int store = PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("ArmourTier") + 1));
                    store -= 10;
                    PlayerPrefs.SetInt("BankedCurrency" + (PlayerPrefs.GetInt("ArmourTier") + 1), store);                    
                    Debug.Log("armor upgrade called");
                    PlayerPrefs.SetInt("ArmourTier", PlayerPrefs.GetInt("ArmourTier") + 1);
                    PlayerPrefs.Save();
                    UpdateIcon();
                }
                else
                {
                    Debug.Log("INSUFFICENT FUNDS");
                }
                break;
            case 1://Weapon                
                if (PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("WeaponTier") + 1)) >= 10)
                {
                    int store = PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("WeaponTier") + 1));
                    store -= 10;
                    PlayerPrefs.SetInt("BankedCurrency" + (PlayerPrefs.GetInt("WeaponTier") + 1), store);
                    Debug.Log("Weapon upgrade Called");
                    PlayerPrefs.SetInt("WeaponTier", PlayerPrefs.GetInt("WeaponTier") + 1);
                    PlayerPrefs.Save();
                    UpdateIcon();
                }
                else
                {
                    Debug.Log("INSUFFICENT FUNDS");
                }
                break;
            case 3://PICK                
                if (PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("PickTier")+1)) >= 10)
                {
                    int store = PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("PickTier")+1));
                    store -= 10;
                    PlayerPrefs.SetInt("BankedCurrency" + (PlayerPrefs.GetInt("PickTier")+1), store);
                    Debug.Log("Pick upgrade Called");
                    PlayerPrefs.SetInt("PickTier", (PlayerPrefs.GetInt("PickTier")+1));
                    PlayerPrefs.Save();
                    UpdateIcon();
                }
                else
                {
                    Debug.Log("INSUFFICENT FUNDS");
                }
                break;
            case 4://BOOTS              
                if (PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("BootTier") + 1)) >= 10)
                {
                    int store = PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("BootTier") + 1));
                    store -= 10;
                    PlayerPrefs.SetInt("BankedCurrency" + (PlayerPrefs.GetInt("BootTier") + 1), store);
                    Debug.Log("Boot upgrade Called");
                    PlayerPrefs.SetInt("BootTier", (PlayerPrefs.GetInt("BootTier") + 1));
                    PlayerPrefs.Save();
                    UpdateIcon();
                }
                else
                {
                    Debug.Log("INSUFFICENT FUNDS");
                }
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
            case 3:
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("PickTier")];
                break;
            case 4:
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("BootTier")];
                break;
            default:
                break;
    }
    }
}
