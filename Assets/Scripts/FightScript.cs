using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FightScript : MonoBehaviour {
    public GameObject PlayerObj;    
    public Canvas fightScene;
    public Canvas resourcePanel;
    public GameObject playerShadow;
    public GameObject enemyShadow;
    public Slider PlayerHealthDisplay;
    public Slider EnemyHealthDisplay;
    PlayerScript Player;
    ShaftObject Enemy;
    bool hasRead= false;
    int enemyHealth;
    float [] enemyAttack;
    float [] enemyDefense;
    float[] playerAttack;
    float[] playerDefense;
    public bool playerTurn;
    public Sprite playerSprite;
    public Sprite EnemySprite;
	// Use this for initialization
	void Start () {
        Player = PlayerObj.GetComponent<PlayerScript>();
        enemyAttack = new float[3];
        enemyDefense = new float[6];
        playerAttack = new float[3];
        playerDefense = new float[6];
        enemyShadow = this.gameObject.transform.GetChild(0).GetChild(5).gameObject;
        playerShadow = this.gameObject.transform.GetChild(0).GetChild(6).gameObject;
    }

    public void ReadInEnemyData()
    {
        Enemy = Player.currentEnemy.GetComponent<ShaftObject>();
        enemyHealth = Enemy.health;
        enemyAttack = Enemy.attack;
        enemyDefense = Enemy.defense;
        EnemyHealthDisplay.maxValue = Enemy.health;
        EnemyHealthDisplay.value = Enemy.health;

    }

    public void ReadInPlayerData()
    {
        playerDefense[0] = Player.armorStyle * 3 * Player.armorTier;  // Damage Absorbtion Slash-  flat damage Reduction.
        playerDefense[1] = Player.armorStyle * 2 * Player.armorTier;  // Damage Absorbtion Pierce-  flat damage Reduction.
        playerDefense[2] = Player.armorStyle * (5 - Player.armorTier);  // Damage Absorbtion crush-  flat damage Reduction.
        playerDefense[3] = (Player.armorStyle*16) * Player.armorTier/1000;  // Damage Reduction Slash - percentage reduction on remaining damage; (Should max out at ~80%)
        playerDefense[4] = (Player.armorStyle * 8) * Player.armorTier/1000;  // Damage Reduction Slash - percentage reduction on remaining damage; (Should max out at ~40%)
        playerDefense[5] = (Player.armorStyle * 4) * Player.armorTier/1000;  // Damage Reduction Slash - percentage reduction on remaining damage; (Should max out at ~20%)
        //Weapon Styles = Knife, Spear, Sword, Mace, WarHammer. Crush steadily increses, Pierce lowers and then rises, Slash steadily drops.
        playerAttack[0] = ((5 - Player.weaponStyle) * 2 * Player.weaponTier) + 1; //Attack Slash
        playerAttack[1] = (Mathf.Abs(4 - Player.weaponStyle) * 2 * Player.weaponTier) + 1 ; //Attack pierce
        playerAttack[2] = ((Player.weaponStyle) * Player.weaponStyle * Player.weaponTier) + 1; //Attack crush
        PlayerHealthDisplay.maxValue = 20;
        PlayerHealthDisplay.value = Player.health;
    }

    // Update is called once per frame
    void Update () {
        if (Player.inFight)
        {
           
            fightScene.enabled = true;
            resourcePanel.enabled = false;
            if (Player.health <= 0)
            {
                Debug.Log("You died");
                Defeat();
            }
            if (!hasRead)
            {
                ReadInPlayerData();
                ReadInEnemyData();
                hasRead = true;
            }

            PlayerHealthDisplay.value = Player.health;
            EnemyHealthDisplay.value = Enemy.health;
            if (playerTurn)
            {
                //NOTHING
            }
            else
            {//Monster Turn
                float totalDamage = 0;
                for (int i = 0; i < 3; i++)
                {
                    float tempDamage;
                    tempDamage = ((enemyAttack[0 + i] * (1 - playerDefense[3 + i])) - playerDefense[0 + i]);
                    if (tempDamage > 0)
                    {
                        totalDamage += tempDamage;
                    }
                }
                Player.health -= (int)totalDamage;
                playerTurn = true;

            }
            if (enemyHealth <= 0)
            {

                Destroy(Player.currentEnemy);
                hasRead = false;
                Victory();
                enemyHealth = 1;
            }
        }
	}

    public void PlayerAttack(int attackStyle)
    {
        float Damage;
        Damage = ((playerAttack[0 + attackStyle] * (1 - enemyDefense[3 + attackStyle])) - enemyDefense[0 + attackStyle]);
        if (Damage > 0)
        {
            enemyHealth -= (int)Damage;
            Enemy.health = enemyHealth;
        }
        playerTurn = false;
    }

    public void Defeat()
    {
        Player.inFight = false;
        fightScene.enabled = false;
        
        SceneManager.LoadScene("UpgradeScene");
    }
    public void Victory()
    {
        fightScene.enabled = false;
        resourcePanel.enabled = true;
        Player.bankedCurrency[0] += 1;
        Player.Bank();
        Player.inFight = false;
    }
}
