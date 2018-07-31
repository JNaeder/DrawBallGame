using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour {

    Vector3 startPos;
    Quaternion startRot;
    Rigidbody2D rB;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        startRot = transform.rotation;
        rB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Reset() {

        transform.position = startPos;
        transform.rotation = startRot;
        if (rB != null) {
            rB.velocity = Vector3.zero;
            rB.angularVelocity = 0;
        }

    }
}
