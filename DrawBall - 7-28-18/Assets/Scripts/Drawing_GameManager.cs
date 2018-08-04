using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SVGImporter;

public class Drawing_GameManager : MonoBehaviour {


	public static GameObject currentPlayerBall;
	public GameObject defaultPlayerBall;

	GameObject[] allPlayerBalls;

	public GameObject line;
    public Color lineColor = Color.white;
	
    public float gravityMult;

    public int score;
    public float timeScore, finalTimeScore;

    public TextMeshProUGUI scoreNum, WinScore, timeNum, winTimeScore, highscoreNum ;

    bool hasStarted, hasWon;
    public bool isDrawing, isErasing;

	public Transform ballStartingPosition;

    DrawCoin[] drawCoins;

    LevelManager lM;
    HighScoreManager hSM;

	Rigidbody2D ballRB;
    GameObject ball;

    Vector2 gravitySetting;
    Vector3 startingBallPos;

    float newTime;
    public int startingCoinNum, currentCoinNum;


    public float maxLineLength;
    public SVGImage lineLeftImageBar;
    float lineLeftPerc, startingLineLength;
    Vector3 lineLeftImageBarScale;

	public bool usePhoneGravity;

    private void Awake()
    {
		SetCurrentPlayerBall();


		if (currentPlayerBall == null)
		{
			Instantiate(defaultPlayerBall, ballStartingPosition.position, Quaternion.identity);
		}
		else
		{
			Instantiate(currentPlayerBall, ballStartingPosition.position, Quaternion.identity);
		}

        ball = FindObjectOfType<Ball>().gameObject;
    }


    // Use this for initialization
    void Start () {
        lM = FindObjectOfType<LevelManager>();
        hSM = FindObjectOfType<HighScoreManager>();
		ballRB = ball.GetComponent<Rigidbody2D>();
        drawCoins = FindObjectsOfType<DrawCoin>();

		isDrawing = true;

        //Setting Start Values
		startingCoinNum = drawCoins.Length;
        currentCoinNum = startingCoinNum;
        startingBallPos = ball.transform.position;      
        startingLineLength = maxLineLength;
        
	}

	
	// Update is called once per frame
	void Update () {
        SetGravity();
        CheckWin();
        SetLineLeftBar();      
		UpdateUIStuff();      
		TimeManager();

        if (isDrawing)
        {
            DrawLineWithMouse();
        }

	}




	void TimeManager(){
		if (hasStarted)
        {
            if (!hasWon)
            {
                timeScore = Time.time - newTime;
            }

        }

	}


	void SetCurrentPlayerBall(){
		allPlayerBalls = Resources.LoadAll<GameObject>("PlayerBalls");


        foreach (GameObject g in allPlayerBalls)
        {
            string savedPlayerBall = PlayerPrefs.GetString("CurrentPlayerBall");
            if (g.name == savedPlayerBall)
            {
                currentPlayerBall = g;

            }
        }

	}


	void UpdateUIStuff(){
		scoreNum.text = score.ToString();
        WinScore.text = score.ToString();
        timeNum.text = timeScore.ToString("F2");
        winTimeScore.text = finalTimeScore.ToString("F2");
        highscoreNum.text = hSM.GetHighScoreForLevel().ToString("F2");

	}


    public void EraseLineWithMouse(GameObject line) {
       
        Line newLine = line.GetComponent<Line>();
        LineRenderer newLineRend = newLine.GetComponent<LineRenderer>();
        float lineLength = newLineRend.positionCount - 2;

        
        maxLineLength += lineLength;
        Destroy(line);
    }


	void DrawLineWithFinger(){
		if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && maxLineLength > 0)
            {
                GameObject newLine = Instantiate(line, Vector2.zero, Quaternion.identity);
                LineRenderer newLineRend = newLine.GetComponent<LineRenderer>();
                newLineRend.startColor = lineColor;
                newLineRend.endColor = lineColor;
            }


            if (touch.phase == TouchPhase.Ended)
            {



            }

        }

	}

	void DrawLineWithMouse(){

		if(Input.GetMouseButtonDown(0) && maxLineLength > 0){
			GameObject newLine = Instantiate(line, Vector2.zero, Quaternion.identity);
            LineRenderer newLineRend = newLine.GetComponent<LineRenderer>();
            newLineRend.startColor = lineColor;
            newLineRend.endColor = lineColor;

		}


	}


    void CheckWin() {
        if (currentCoinNum <= 0) {
			if (!hasWon)
			{
				lM.WinScreen();
				finalTimeScore = timeScore;
				SetMoneyNumber();
				if (finalTimeScore < hSM.GetHighScoreForLevel())
				{
					hSM.SetNewHighScore(finalTimeScore);
				}


				hasWon = true;
			}
            
        }
        

        
    }


	void SetMoneyNumber(){

		ShopManager.moneyNum += 5;
		PlayerPrefs.SetInt("Money", ShopManager.moneyNum);

	}


    void SetGravity() {
        

		if(!usePhoneGravity){
			Physics2D.gravity = new Vector2(0, - 20);

		} else {
			gravityMult = 20;
			Vector2 accelPos = Input.acceleration * gravityMult;
            Physics2D.gravity = accelPos;
		}


    }



	public void DropBall(){
		ballRB.isKinematic = false;
        newTime = Time.time;
        hasStarted = true;
	}

    void SetLineLeftBar() {
        lineLeftPerc = maxLineLength / startingLineLength;
        lineLeftImageBarScale = new Vector3(lineLeftPerc, 1, 1);
        lineLeftImageBar.transform.localScale = lineLeftImageBarScale;


    }



    public void ResetBall() {
        currentCoinNum = startingCoinNum;
        ballRB.isKinematic = true;
        ballRB.velocity = Vector2.zero;
        ballRB.angularVelocity = 0;
        hasStarted = false;
		hasWon = false;
		timeScore = 0;

        for (int i = 0; i < drawCoins.Length; i++) {
            drawCoins[i].gameObject.SetActive(true);

        }

        ResetObject[] resetObjects = FindObjectsOfType<ResetObject>();
        for (int i = 0; i < resetObjects.Length; i++) {
            resetObjects[i].Reset();

        }


        ball.transform.position = startingBallPos;

    }

	public void ClearLines()
	{
		Line[] allLines = FindObjectsOfType<Line>();
		foreach (Line l in allLines)
		{
			Destroy(l.gameObject);

		}
		maxLineLength = startingLineLength;
	}



    public void SetMode(string mode) {
        if (mode == "Draw")
        {
            isDrawing = true;
            isErasing = false;
        }
        else if (mode == "Erase") {
            isDrawing = false;
            isErasing = true;
        }

    }


}
