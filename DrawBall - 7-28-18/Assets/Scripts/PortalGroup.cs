using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGroup : MonoBehaviour {

    public PortalTrigger portal1;
    public PortalTrigger portal2;

    Ball playerBall;

	// Use this for initialization
	void Start () {
        playerBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Teleport(string portalName) {

        Transform playerBallTrans = playerBall.transform;
        if (portalName == "Portal 1")
        {
            playerBallTrans.position = portal2.transform.position;
        }
        else if (portalName == "Portal 2") {

            playerBallTrans.position = portal1.transform.position;
        }

    }
}
