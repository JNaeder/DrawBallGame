using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour {
    
    
    public LevelButton[] levelButtons;


	// Use this for initialization
	void Start () {
        levelButtons = GetComponentsInChildren<LevelButton>();
		SetNumbersForButtons();
	}


	public void SetNumbersForButtons(){
		for (int i = 0; i < levelButtons.Length; i++){
			levelButtons[i].SetLevelNumber(i + 1);
			 
		}

	}
	


    void SetEveryButtonAboveToDisable(int levelNum) {
        for (int i = levelNum; i < 6; i++) {
            Button newButton = levelButtons[i].GetComponent<Button>();
            newButton.interactable = false;

        }

    }


    

    
}
