using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShaftObject : MonoBehaviour
{
    public bool isOre;
    public int tier = 1;
    public float [] defense;
    public float [] attack;
    public int health;
    public GameManager manager;
    public PlayerScript player;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
        if (!isOre)
        {
            player.Bank();
            player.StoreData();
            player.currentEnemy = gameObject;
            SpriteRenderer MSR = gameObject.GetComponent<SpriteRenderer>();
            MSR.enabled = false;
            player.inFight = true;
        }
        else
        {
            player.tempCurrency[tier] += (1+ 1*player.pickTier);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.inFight) {
            Vector3 newPos = gameObject.transform.position;
            newPos.y += 3 * Time.deltaTime;
            gameObject.transform.position = newPos;
            if (Camera.main.WorldToViewportPoint(gameObject.transform.position).y > 1)
            {
                Destroy(gameObject);
            }
        }

    }
}
