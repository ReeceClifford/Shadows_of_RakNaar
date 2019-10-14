using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    // link level mananager of script to kill player in empty format
    public LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        // Fills levelManager from scene
        levelManager = FindObjectOfType<LevelManager>();
    }


    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
        }
    }

}
