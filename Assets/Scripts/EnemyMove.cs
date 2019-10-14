using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float moveSpeed;
    public bool moveRight;

    public float wallCheckRadius;
    public Transform wallCheck;
    public LayerMask whatIsWall;
    private bool hittingWall;
    private bool noFloor;
    public Transform floorCheck;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        noFloor = Physics2D.OverlapCircle(floorCheck.position, wallCheckRadius, whatIsWall);
        if (hittingWall || !noFloor)
            moveRight = !moveRight;
       

        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        } else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

	}
}
