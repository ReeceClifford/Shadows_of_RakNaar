using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowController : MonoBehaviour {

    public float speed;

    public PlayerController player;
    public GameObject enemyDeathObjectEffect;
    public float rotateSpeed;
    public int damageToDeal;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        if(player.transform.localScale.x < 0)
        {
            speed = -speed;
            rotateSpeed = -rotateSpeed;

        }
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        // Makes Projectile Spin
        GetComponent<Rigidbody2D>().angularVelocity = rotateSpeed;
	}
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //Instantiate(enemyDeathObjectEffect, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
            //VoidEssenceManager.AddCurrencyOnKill();

            other.GetComponent<EnemyHealthManager>().dealDamage(damageToDeal);
            Destroy(gameObject);
        }
        if(other.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if(other.tag == "Boss")
        {
            other.GetComponent<BossHealthManager>().dealDamage(damageToDeal);
            Destroy(gameObject);
        }
       
    }
}
