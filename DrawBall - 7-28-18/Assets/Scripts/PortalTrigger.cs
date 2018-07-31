using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour {

    public Transform portalTrigger;
    Ball playerBall;

	// Use this for initialization
	void Start () {
        playerBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 newPos = portalTrigger.position;
        Rigidbody2D rB = collision.gameObject.GetComponent<Rigidbody2D>();
        float rBMag = rB.velocity.magnitude;

        rB.velocity = Vector2.zero;
        rB.angularVelocity = 0;

        playerBall.transform.position = newPos;
        rB.velocity = portalTrigger.up * rBMag;
    }
}
