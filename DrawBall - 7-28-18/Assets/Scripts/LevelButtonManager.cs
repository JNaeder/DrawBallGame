using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour {
    
    
    public LevelButton[] levelButtons;
	public int startLevelScene;



	// Use this for initialization
	void Start () {
        levelButtons = GetComponentsInChildren<LevelButton>();
		SetNumbersForButtons();
	}


	public void SetNumbersForButtons(){
		for (int i = 0; i < levelButtons.Length; i++)
		{
			levelButtons[i].SetLevelNumber(i + 1);
			levelButtons[i].SetSceneToButton(startLevelScene + i);

			Button newButton = levelButtons[i].GetComponent<Button>();
		}

	}
	


    void SetEveryButtonAboveToDisable(int levelNum) {
        for (int i = levelNum; i < 6; i++) {
            Button newButton = levelButtons[i].GetComponent<Button>();
            newButton.interactable = false;

        }

    }


    

    
}
