using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VoidEssenceManager : MonoBehaviour {

    public static int currency;
    Text text;

    // This will be ran on start of project
    void Start()
    {
        // Get Text Component in order to begin displaying currency
        text = GetComponent<Text>();
        currency = 0;
    }
    // Ran after preset frames past
    void Update()
    {
        if(currency < 0)
        {
            currency = 0;
        }
        text.text = "" + currency;
    }
    // Used to Add Currency for Pickups
    public static void AddCurrency(int currencyToAdd)
    {
        currency += currencyToAdd;
    }
    // Used to Add Currency for Kills
    public static void AddCurrencyOnKill(int addCurrencyOnKill)
    {
        currency += addCurrencyOnKill;
    }
    // Used to Reduce currency on death
    public static void RemoveCurrencyOnDeath()
    {
        currency /= 2;
    }
    // Used to Remove Currency on Upgrade
    public static void RemoveCurrencyOnUpgrade(int currencyToRemoveOnUpgrade)
    {
        // Feature coming soon
    }
    // Used to Reset currency to 0
    public static void ResetCurrency(int currencyReset)
    {
        currency = 0;
    }
}
