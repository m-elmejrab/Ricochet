using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool moveLeft = false;
    bool moveRight = false;
    bool moveUp = false;
    bool moveDown = false;

    Rigidbody2D rb;
    public float moveForce = 5f;
    public float playerMaxSpeed = 10f;



    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey("d"))
        {
            moveRight = true;

        }
        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
        if (Input.GetKey("w"))
        {
            moveUp = true;

        }
        if (Input.GetKey("s"))
        {
            moveDown = true;
        }


    }

    void FixedUpdate()
    {
        if (moveRight == true)
        {
            moveRight = false;
            if (rb.velocity.magnitude <= playerMaxSpeed)
                rb.AddForce(new Vector2(moveForce, 0) * Time.deltaTime);
        }
        if (moveLeft == true)
        {
            moveLeft = false;
            if (rb.velocity.magnitude <= playerMaxSpeed)
                rb.AddForce(new Vector2(-moveForce, 0) * Time.deltaTime);

        }
        if (moveUp == true)
        {
            moveUp = false;
            if (rb.velocity.magnitude <= playerMaxSpeed)
                rb.AddForce(new Vector2(0, moveForce) * Time.deltaTime);

        }
        if (moveDown == true)
        {
            moveDown = false;
            if (rb.velocity.magnitude <= playerMaxSpeed)
                rb.AddForce(new Vector2(0, -moveForce) * Time.deltaTime);
        }

    }
}
