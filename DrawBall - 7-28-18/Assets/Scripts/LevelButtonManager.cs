using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour {
    
    public TextMeshProUGUI[] highscoreNumbers;
    LevelButton[] levelButtons;
    


	// Use this for initialization
	void Start () {
        levelButtons = GetComponentsInChildren<LevelButton>();
        SetHIghScoresForButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetEveryButtonAboveToDisable(int levelNum) {
        for (int i = levelNum; i < 6; i++) {
            Button newButton = levelButtons[i].GetComponent<Button>();
            newButton.interactable = false;
            levelButtons[i].HideText();

        }

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
               SetEveryButtonAboveToDisable(i);
            }

        }


    }
    

    
}
