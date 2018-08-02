using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndlessMode : MonoBehaviour {

	public static EndlessMode inst;


	public static int levelNum;

	public GameObject drawCoin;
	public GameObject obstacle;
	public GameObject spinningWheel;

	public TextMeshProUGUI levelNumScore;

	Transform drawCoinPosGroup;
	Transform[] drawCoinPositions;

	int numOfDrawCoins;
	int numOfObstacles;
	int numOfSpinningWheels;
      
	List<Transform> newPos;

	LevelManager lM;



	// Use this for initialization
	void Awake() {
		lM = FindObjectOfType<LevelManager>();
		drawCoinPosGroup = FindObjectOfType<DrawCoinPosGroup>().transform;

		newPos = new List<Transform>();

		SetDrawCoinPositions();
		SpawnLevel();
	}


	public void SpawnLevel(){
		levelNumScore.text = (levelNum + 1).ToString();


		numOfDrawCoins = Mathf.Clamp(levelNum + 2, 2, 24);
		numOfObstacles = Mathf.Clamp(levelNum - 2, 0, 4);
		numOfSpinningWheels = Mathf.Clamp(levelNum - 4, 0, 3);




		SpawnDrawCoins(numOfDrawCoins);
		SpawnObstacles(numOfObstacles);
		SpawnSpinningWheels(numOfSpinningWheels);

	}


	public void NextLevel(){
		int SceneNum = SceneManager.GetActiveScene().buildIndex;
		levelNum++;
		lM.LoadScene(SceneNum);
        

	}

	public void ResetLevelNum(){
		levelNum = 0;

	}


	void SetDrawCoinPositions(){
		foreach(Transform t in drawCoinPosGroup){
			newPos.Add(t);
                             
		}

		drawCoinPositions = newPos.ToArray();

	}

	void SpawnDrawCoins(int coinNum){


		for (int i = 0; i < coinNum; i++)
		{
			int randNum = Random.Range(0, drawCoinPositions.Length);
			GameObject newCoin = Instantiate(drawCoin, drawCoinPositions[randNum].position, Quaternion.identity);

			newPos.Remove(drawCoinPositions[randNum]);
			drawCoinPositions = newPos.ToArray();

		}

	}

	void SpawnObstacles(int num){
		for (int i = 0; i < num; i++)
        {
            int randNum = Random.Range(0, drawCoinPositions.Length);
			Instantiate(obstacle, drawCoinPositions[randNum].position, Quaternion.identity);

            newPos.Remove(drawCoinPositions[randNum]);
            drawCoinPositions = newPos.ToArray();

        }

	}

	void SpawnSpinningWheels(int num){
		for (int i = 0; i < num; i++)
        {
            int randNum = Random.Range(0, drawCoinPositions.Length);
			GameObject newWheel = Instantiate(spinningWheel, drawCoinPositions[randNum].position, Quaternion.identity);
			Rotate wheelRot = newWheel.GetComponent<Rotate>();
			wheelRot.speed = levelNum * 10;

            newPos.Remove(drawCoinPositions[randNum]);
            drawCoinPositions = newPos.ToArray();

        }

	}
}
