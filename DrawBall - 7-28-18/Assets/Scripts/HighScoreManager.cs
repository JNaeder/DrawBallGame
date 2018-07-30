using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetNewHighScore(float timeScore) {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetFloat("Level_" + sceneNumber.ToString(), timeScore);
        Debug.Log("New Highscore is " + timeScore);
    }



    public float GetHighScoreForLevel() {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        float currentHighScore = PlayerPrefs.GetFloat("Level_" + sceneNumber.ToString());
        return currentHighScore;

    }

    public void ResetAllHighScores() {
        for (int i = 1; i < 10; i++) {
            PlayerPrefs.SetFloat("Level_" + i, 999);

        }


    }

    public void OpenAllStages()
    {
        for (int i = 1; i < 10; i++)
        {
            PlayerPrefs.SetFloat("Level_" + i,50);

        }


    }
}
