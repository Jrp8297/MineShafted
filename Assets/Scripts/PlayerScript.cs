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
    public int pickTier;
    public int spearTier;
    public int bootTier;
    public int hammerTier;
	public Sprite [] armorImages;
	public Sprite [] weaponImages;
	public Sprite [] pickImages;
	public Sprite [] spearImages;
	public Sprite [] bootImages;
	public Sprite [] hammerImages;
    public float tempDepth;
    public bool inFight;
    public bool TickDebug;
    public bool DoReset;
    public float depth;
    public GameObject currentEnemy;
	public GameObject pickSprite;
	public GameObject armorSprite;
	public GameObject bootSprite;
    Vector3 position;
    Vector3 velocity;



    // Use this for initialization
    void Start () {
        tempCurrency = new int[10];
        bankedCurrency = new int[10];
        GetData();
	}
	
	// Update is called once per frame
	void Update () {
        position = gameObject.transform.position;
      
        //Debug.Log(tempDepth);
        PlayerPrefs.SetFloat("TempDepth", tempDepth);

		pickSprite.GetComponent<SpriteRenderer> ().sprite = pickImages [pickTier];
		armorSprite.GetComponent<SpriteRenderer> ().sprite = armorImages [armorTier];
		bootSprite.GetComponent<SpriteRenderer> ().sprite = bootImages [bootTier];

        if (TickDebug)
        {

            GetData();
            TickDebug = false;
        }
        if (DoReset)
        {
            DoReset = false;
            ResetData();
        }
        if (!inFight)
        {
            tempDepth += Time.deltaTime;//move the player "down" the shaft as time passes
            
             velocity = new Vector3(Input.acceleration.x,0,0);
            
            
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
            
            position += velocity;
            gameObject.transform.position = position;

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
            pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
    public void StoreData()    {
       
        PlayerPrefs.SetInt("Health", health);
        for (int i = 0; i <= 9; i++)
        {
            PlayerPrefs.SetInt("TempCurrency" +i, tempCurrency[i]);
        }
        for (int i = 0; i <= 9; i++)
        {
            PlayerPrefs.SetInt("BankedCurrency" + i, bankedCurrency[i]);
        }
        PlayerPrefs.SetInt("ArmourType", armorStyle);
        PlayerPrefs.SetInt("ArmourTier", armorTier);
        PlayerPrefs.SetInt("WeaponType", weaponStyle);
        PlayerPrefs.SetInt("WeaponTier", weaponTier);
        PlayerPrefs.SetInt("PickTier", pickTier);
        PlayerPrefs.SetInt("SpearTier", spearTier);
        PlayerPrefs.SetInt("HammerTier", hammerTier);
        PlayerPrefs.SetInt("BootTier", bootTier);
        PlayerPrefs.SetFloat("TempDepth", tempDepth);
        PlayerPrefs.Save();
    }
    void GetData()
    {
        PlayerPrefs.GetInt("Health", health);
        for (int i = 0; i <= 9; i++)
        {
            tempCurrency[i] =PlayerPrefs.GetInt("TempCurrency" + i);
        }
        for (int i = 0; i <= 9; i++)
        {
            bankedCurrency[i]= PlayerPrefs.GetInt("BankedCurrency" + i.ToString());
        }
        armorStyle= PlayerPrefs.GetInt("ArmourType");
        armorTier=PlayerPrefs.GetInt("ArmourTier");
        weaponStyle =PlayerPrefs.GetInt("WeaponType");
        weaponTier=PlayerPrefs.GetInt("WeaponTier");
        pickTier=PlayerPrefs.GetInt("PickTier");
        spearTier=PlayerPrefs.GetInt("SpearTier");
        bootTier = PlayerPrefs.GetInt("BootTier");
        tempDepth = PlayerPrefs.GetInt("TempDepth");
        hammerTier = PlayerPrefs.GetInt("HammerTier");
           }
    void ResetData()
    {
        PlayerPrefs.SetInt("Health", 10);
        for (int i = 0; i <= 9; i++)
        {
            PlayerPrefs.SetInt("TempCurrency" + i.ToString(), 0);
        }
        for (int i = 0; i <= 9; i++)
        {
            PlayerPrefs.SetInt("BankedCurrency" + i.ToString(), 0);
        }
        PlayerPrefs.SetInt("ArmourType", 0);
        PlayerPrefs.SetInt("ArmourTier", 0);
        PlayerPrefs.SetInt("WeaponType", 0);
        PlayerPrefs.SetInt("WeaponTier", 0);
        PlayerPrefs.SetInt("SpearTier", 0);
        PlayerPrefs.SetInt("PickTier", 0);
        PlayerPrefs.SetInt("BootTier", 0);
        PlayerPrefs.SetInt("TempDepth", 0);
        PlayerPrefs.SetInt("HammerTier", 0);
        PlayerPrefs.Save();
    }
    
    public void Bank()
    {
       
        for (int i = 0; i <= 9; i++)
        {
            bankedCurrency[i] += tempCurrency[i];
            tempCurrency[i] = 0;
        }
        StoreData();
    }
    void DebugData()
    {
        GetData();
        
      
    }

    public void Alloy( int whichAlloy)
    {//For now, this just alloys copper and tin into bronze

        if (whichAlloy == 2)//If we are making Bronze
        {
            if (bankedCurrency[1] >= 9 && bankedCurrency[9] >= 1)
            {
                bankedCurrency[1] -= 9;//take away 9 copper
                bankedCurrency[9] -= 1;//take away 1 tin
                bankedCurrency[2] += 10;// add 10 bronze
            }
            Bank();

        }
        else if (whichAlloy == 4)//If we are making Steel
        {
            if (bankedCurrency[3] >= 9 && bankedCurrency[8] >= 1)
            {
                bankedCurrency[3] -= 9;//take away 9 Iron
                bankedCurrency[8] -= 1;//take away 1 Nickel
                bankedCurrency[4] += 10;// add 10 steel
            }
            Bank();

        }
        else if (whichAlloy == 5)//If we are making Gilded Steel
        {
            if (bankedCurrency[4] >= 1 && bankedCurrency[7] >= 1)
            {
                bankedCurrency[3] -= 1;//take away 1 steel
                bankedCurrency[7] -= 1;//take away 1 gold
                bankedCurrency[5] += 2;// add 2 Gilded Steel
            }
            Bank();

        }

    }
}
