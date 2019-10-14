using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    public float wallCheckRadius;
    public Transform wallCheck;
    public LayerMask whatIsWall;
    private bool hittingWall;
    private bool noFloor;
    public Transform floorCheck;

    private float ySize;

    // Use this for initialization
    void Start()
    {
        ySize = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        noFloor = Physics2D.OverlapCircle(floorCheck.position, wallCheckRadius, whatIsWall);
        if (hittingWall || !noFloor)
            moveRight = !moveRight;


        if (moveRight)
        {
            transform.localScale = new Vector3(-ySize, transform.localScale.y, transform.localScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(ySize, transform.localScale.y, transform.localScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

    }
}
