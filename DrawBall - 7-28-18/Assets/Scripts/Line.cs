using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Line : MonoBehaviour {

	public float threshold;

    LineRenderer lineRend;
    EdgeCollider2D edgeColl;
    Drawing_GameManager dGM;
	LevelManager lM;
    Camera cam;


    Vector3 touchPos;

    List<Vector2> linePositions;
    Vector2 lastPos;

	bool hasEnded;

	// Use this for initialization
	void Start () {

		lM = FindObjectOfType<LevelManager>();
		lineRend = GetComponent<LineRenderer>();
		edgeColl = GetComponent<EdgeCollider2D>();
        dGM = FindObjectOfType<Drawing_GameManager>();

		cam = Camera.main;

        linePositions = new List<Vector2>();
		
	}

	// Update is called once per frame
	void Update()
	{
		//DrawWithFinger();
		DrawWithMouse();



	}



	void DrawWithMouse() { 
		if(!hasEnded){
			if(Input.GetMouseButton(0) && dGM.maxLineLength > 0){
				touchPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

				if (!lM.isPaused)
				{
					if (Mathf.Abs(lastPos.x - touchPos.x) > threshold || Mathf.Abs(lastPos.y - touchPos.y) > threshold)
					{
						if (!EventSystem.current.IsPointerOverGameObject())
						{
							linePositions.Add(touchPos);
							lineRend.positionCount = linePositions.Count;
							lineRend.SetPosition(linePositions.Count - 1, touchPos);
							edgeColl.points = linePositions.ToArray();
							lastPos = touchPos;
							if (linePositions.Count > 2)
							{
								dGM.maxLineLength--;
							}
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0))
            {
                hasEnded = true;
                if (linePositions.Count < 2)
                {
                    Destroy(gameObject);
                }
            }

		}
	
	
	}

	void DrawWithFinger()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

			if (!hasEnded)
			{
				if (!lM.isPaused)
				{
					if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
					{
						if (touch.phase == TouchPhase.Moved && dGM.maxLineLength > 0)
						{

							touchPos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
							if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
							{

								if (Mathf.Abs(lastPos.x - touchPos.x) > threshold || Mathf.Abs(lastPos.y - touchPos.y) > threshold)
								{
									linePositions.Add(touchPos);
									lineRend.positionCount = linePositions.Count;
									lineRend.SetPosition(linePositions.Count - 1, touchPos);
									edgeColl.points = linePositions.ToArray();
									lastPos = touchPos;
									if (linePositions.Count > 2)
									{
										Debug.Log("TakeAway Line length");
										dGM.maxLineLength--;
									}
								}
							}

						}

						if (touch.phase == TouchPhase.Ended)
						{
							hasEnded = true;
							if (linePositions.Count < 2)
							{
								Destroy(gameObject);
							}
						}
					}
				}

			}


        }

    }
}
