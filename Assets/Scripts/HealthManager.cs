using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour {

    public static int playerMaxHealth;
    public static int playerHealth;
    public bool isDead;
    public static int defaultPlayerMaxHealth = 5;
    //Text text;

    public Slider healthBar;
    
    private LevelManager levelManager;
    public Transform healthRegen;


	///Use this for initialization
	void Start () {

        //text = GetComponent<Text>();
        healthBar = GetComponent<Slider>();
        playerMaxHealth = defaultPlayerMaxHealth;
        playerHealth = defaultPlayerMaxHealth;
        levelManager = FindObjectOfType<LevelManager>();
        InvokeRepeating("NotFullHealth", 10.0f, 5.0f);
        isDead = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			//text.text = "" + playerHealth + " / " + playerMaxHealth;
			levelManager.RespawnPlayer ();
			isDead = true;
		}
        // else {
        //	//text.text = "" + playerHealth + " / " + playerMaxHealth;

        //}
        healthBar.maxValue = playerMaxHealth;
        healthBar.value = playerHealth;
        
	}

    public static void DamagePlayer(int damageToDeal)
    {
        playerHealth -= damageToDeal;
    }
    public void FullHealth(){
        playerHealth = playerMaxHealth;
    }
    public void NotFullHealth()
    {
        if (playerHealth < playerMaxHealth)
        {
            playerHealth += 1;
        }
           
    }
 
}
