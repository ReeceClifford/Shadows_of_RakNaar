using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnContact : MonoBehaviour {

    public int damageToDeal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            HealthManager.DamagePlayer(damageToDeal);
            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.knockbackLength;
            if(other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }
        }
    }
}
