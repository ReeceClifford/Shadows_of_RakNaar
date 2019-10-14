using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;
    public GameObject respawnParticle;
    public GameObject deathParticle;
    public float respawnDelay;
    private new CameraController camera;
    public int currencyToRemoveOnDeath = 2;
    public HealthManager healthManager;

    // Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<HealthManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Handle Player Respawn
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        // Creates a copy of Object
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        camera.isFollowing = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        VoidEssenceManager.RemoveCurrencyOnDeath();
        // Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        camera.isFollowing = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 5f;
        player.playerInsanity = player.playerInsanity * 1.02f;
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
