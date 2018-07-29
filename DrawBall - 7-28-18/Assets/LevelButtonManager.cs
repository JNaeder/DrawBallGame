using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelButtonManager : MonoBehaviour {
    
    public TextMeshProUGUI[] highscoreNumbers;


	// Use this for initialization
	void Start () {
        SetHIghScoresForButtons();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetHIghScoresForButtons() {
        for (int i = 1; i < highscoreNumbers.Length; i++) {
            float score = PlayerPrefs.GetFloat("Level_" + i);
            if (score != 999)
            {
                highscoreNumbers[i - 1].text = score.ToString("F2");
            }
            else {
                highscoreNumbers[i - 1].text = " 00:00";

            }

        }


    }
    

    
}
