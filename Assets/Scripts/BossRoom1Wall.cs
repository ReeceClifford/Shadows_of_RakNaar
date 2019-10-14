using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom1Wall : MonoBehaviour {

    public int currencyOnKill;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (FindObjectOfType<BossHealthManager>())
        {
            return;
        }
        else
        {
            currencyOnKill = Random.Range(1000, 1501);
            VoidEssenceManager.AddCurrencyOnKill(currencyOnKill);
            Destroy(gameObject);
        }
	}
}
