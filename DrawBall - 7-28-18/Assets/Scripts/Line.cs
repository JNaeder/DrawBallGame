﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	public float threshold;

    LineRenderer lineRend;
    EdgeCollider2D edgeColl;
    Drawing_GameManager dGM;
    Camera cam;


    Vector3 touchPos;

    List<Vector2> linePositions;
    Vector2 lastPos;

	bool hasEnded;

	// Use this for initialization
	void Start () {

		lineRend = GetComponent<LineRenderer>();
		edgeColl = GetComponent<EdgeCollider2D>();
        dGM = FindObjectOfType<Drawing_GameManager>();

		cam = Camera.main;

        linePositions = new List<Vector2>();
		
	}
	
	// Update is called once per frame
	void Update () {
		DrawWithFinger();
	}

	void DrawWithFinger()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

			if (!hasEnded)
			{

				if (touch.phase == TouchPhase.Moved && dGM.maxLineLength > 0)
				{

                    touchPos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
					

					if (Mathf.Abs(lastPos.x - touchPos.x) > threshold || Mathf.Abs(lastPos.y - touchPos.y) > threshold)
					{
						linePositions.Add(touchPos);
						lineRend.positionCount = linePositions.Count;
						lineRend.SetPosition(linePositions.Count - 1, touchPos);
						edgeColl.points = linePositions.ToArray();
						lastPos = touchPos;

                        dGM.maxLineLength--;
					}

				}
				if(touch.phase == TouchPhase.Ended){
					hasEnded = true;
                    if (linePositions.Count < 2) {
                        Destroy(gameObject);
                    }
				}

			}


        }

    }
}
