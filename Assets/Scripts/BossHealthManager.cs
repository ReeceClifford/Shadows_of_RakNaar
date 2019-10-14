
using System.Collections;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

    public int enemyHealth;
    public GameObject deathEffect;
    public GameObject bossPrefab;
    public float minSize;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);


            if(transform.localScale.y > minSize)
            {
                GameObject bossClone1 = Instantiate(bossPrefab, new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
                GameObject bossClone2 = Instantiate(bossPrefab, new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z), transform.rotation) as GameObject;

                bossClone1.transform.localScale = new Vector3(transform.localScale.y * 0.7f, transform.localScale.y * 0.7f, transform.localScale.z);
                bossClone1.GetComponent<BossHealthManager>().enemyHealth = 20;
                bossClone1.GetComponent<BossMovement>().moveSpeed += 0.5f;
                bossClone1.GetComponent<DamagePlayerOnContact>().damageToDeal += 1;
                bossClone2.transform.localScale = new Vector3(transform.localScale.y * 0.7f, transform.localScale.y * 0.7f, transform.localScale.z);
                bossClone2.GetComponent<BossMovement>().moveSpeed += 0.5f;
                bossClone1.GetComponent<DamagePlayerOnContact>().damageToDeal += 1;
                bossClone2.GetComponent<BossHealthManager>().enemyHealth = 20;
            }
            Destroy(gameObject);
        }


    }
		
    public void dealDamage(int damageToDeal)
    {
        enemyHealth -= damageToDeal;
    }
}