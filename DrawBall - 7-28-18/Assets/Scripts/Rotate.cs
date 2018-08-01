using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public Transform thingToRotate;
	public bool spinningLeft;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (spinningLeft)
		{
			thingToRotate.Rotate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
		} else {

			thingToRotate.Rotate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
		}
		
	}
}
