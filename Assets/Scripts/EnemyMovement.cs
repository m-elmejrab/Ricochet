using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Rigidbody2D rb;
    float maxVelocity = 0f;
	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if(rb.velocity.magnitude>maxVelocity)
        {
            maxVelocity = rb.velocity.magnitude;
        }
        if(rb.velocity.magnitude < maxVelocity)
        {
            rb.AddForce(transform.InverseTransformDirection(rb.velocity) * 5f * Time.deltaTime);
        }
    }
}
