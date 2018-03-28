using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeObject : MonoBehaviour {
    public Sprite [] objectsToDisplay;
    Image myImage;    
    
    public int storeSlot;
    public Slider[] ObjectStats;
    

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
            case 5://SPEAR             
                if (PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("SpearTier") + 1)) >= 10)
                {
                    int store = PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("SpearTier") + 1));
                    store -= 10;
                    PlayerPrefs.SetInt("BankedCurrency" + (PlayerPrefs.GetInt("SpearTier") + 1), store);
                    Debug.Log("Spear upgrade Called");
                    PlayerPrefs.SetInt("SpearTier", (PlayerPrefs.GetInt("SpearTier") + 1));
                    PlayerPrefs.Save();
                    UpdateIcon();
                }
                else
                {
                    Debug.Log("INSUFFICENT FUNDS");
                }
                break;
            case 6://HAMMER            
                if (PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("HammerTier") + 1)) >= 10)
                {
                    int store = PlayerPrefs.GetInt("BankedCurrency" + (PlayerPrefs.GetInt("HammerTier") + 1));
                    store -= 10;
                    PlayerPrefs.SetInt("BankedCurrency" + (PlayerPrefs.GetInt("HammerTier") + 1), store);
                    Debug.Log("Hammer upgrade Called");
                    PlayerPrefs.SetInt("HammerTier", (PlayerPrefs.GetInt("HammerTier") + 1));
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
                ObjectStats[0].value = 4 * 2 * PlayerPrefs.GetInt("WeaponTier")+1;
                ObjectStats[1].value = 3 * 2 * PlayerPrefs.GetInt("WeaponTier")+1;
                ObjectStats[2].value = 1 * PlayerPrefs.GetInt("WeaponTier") * PlayerPrefs.GetInt("WeaponTier") + 1;
                break;
            case 2:
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("ArmourTier")];
                ObjectStats[0].value = 1 * 3 * PlayerPrefs.GetInt("ArmourTeir");//DA slash
                ObjectStats[1].value = 16.0f  * PlayerPrefs.GetInt("ArmourTeir")/1000;//Dr SLash
                ObjectStats[2].value = 1 * 2 * PlayerPrefs.GetInt("ArmourTeir");//DA Pierce
                ObjectStats[3].value = 8.0f * 3 * PlayerPrefs.GetInt("ArmourTeir")/1000;//DR Pierce
                ObjectStats[4].value = 1 * (5- PlayerPrefs.GetInt("ArmourTeir"));//DA crush
                ObjectStats[5].value = 4.0f * PlayerPrefs.GetInt("ArmourTeir")/1000;//DR Crush
                break;
            case 3:
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("PickTier")];
                ObjectStats[0].value = PlayerPrefs.GetInt("PickTier");
                break;
            case 4:
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("BootTier")];
                ObjectStats[0].value = PlayerPrefs.GetInt("BootTier");
                break;
            case 5:
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("SpearTier")];         
                ObjectStats[0].value = 2 * 2 * PlayerPrefs.GetInt("WeaponTier") + 1;
                ObjectStats[1].value = 5 * 2 * PlayerPrefs.GetInt("WeaponTier") + 1;
                ObjectStats[2].value = 1 * PlayerPrefs.GetInt("WeaponTier") * PlayerPrefs.GetInt("WeaponTier") + 1;
                break;
            case 6:
                myImage.sprite = objectsToDisplay[PlayerPrefs.GetInt("HammerTier")];
                ObjectStats[0].value = 1 * 2 * PlayerPrefs.GetInt("WeaponTier") + 1;
                ObjectStats[1].value = 1 * 2 * PlayerPrefs.GetInt("WeaponTier") + 1;
                ObjectStats[2].value = 3 * PlayerPrefs.GetInt("WeaponTier") * PlayerPrefs.GetInt("WeaponTier") + 1;
                break;
            default:
                break;
    }
    }
}
