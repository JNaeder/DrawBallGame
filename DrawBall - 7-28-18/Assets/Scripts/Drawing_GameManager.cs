using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Drawing_GameManager : MonoBehaviour {

	public GameObject line;
    public Color lineColor = Color.white;
	
    public float gravityMult;

    public int score;
    public float timeScore, finalTimeScore;

    public TextMeshProUGUI scoreNum, WinScore, timeNum, winTimeScore, highscoreNum ;

    bool hasStarted, hasWon;

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
    public Image lineLeftImageBar;
    float lineLeftPerc, startingLineLength;
    Vector3 lineLeftImageBarScale;

    private void Awake()
    {
        ball = FindObjectOfType<Ball>().gameObject;
    }


    // Use this for initialization
    void Start () {
        lM = FindObjectOfType<LevelManager>();
        hSM = FindObjectOfType<HighScoreManager>();
        
		ballRB = ball.GetComponent<Rigidbody2D>();
        drawCoins = FindObjectsOfType<DrawCoin>();
        startingCoinNum = drawCoins.Length;
        currentCoinNum = startingCoinNum;

		gravityMult = LevelManager.gravityMult;

        startingBallPos = ball.transform.position;

        startingLineLength = maxLineLength;
        
	}

	
	// Update is called once per frame
	void Update () {
        SetGravity();
        CheckWin();
        SetLineLeftBar();

        scoreNum.text = score.ToString();
        WinScore.text = score.ToString();
        timeNum.text = timeScore.ToString("F2");
        winTimeScore.text = finalTimeScore.ToString("F2");
        highscoreNum.text = hSM.GetHighScoreForLevel().ToString("F2");


        if (hasStarted) {
            
                timeScore = Time.time - newTime;
            
        }

		if(Input.touchCount  > 0){
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began && maxLineLength > 0){
				GameObject newLine = Instantiate(line, Vector2.zero, Quaternion.identity);
                LineRenderer newLineRend = newLine.GetComponent<LineRenderer>();
                newLineRend.startColor = lineColor;
                newLineRend.endColor = lineColor;
			}


			if(touch.phase == TouchPhase.Ended){



			}

		}

	}


    void CheckWin() {
        if (currentCoinNum <= 0) {
            lM.WinScreen();
            hasWon = true;
            
            if (timeScore < hSM.GetHighScoreForLevel())
            {
                hSM.SetNewHighScore(timeScore);

            }
            finalTimeScore = timeScore;
        }
        

        
    }


    void SetGravity() {
        Vector2 accelPos = Input.acceleration * gravityMult;
        Physics2D.gravity = accelPos;


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
        hasStarted = false;

        for (int i = 0; i < drawCoins.Length; i++) {
            drawCoins[i].gameObject.SetActive(true);

        }

        ball.transform.position = startingBallPos;

    }


}
