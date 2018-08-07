using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour {
    
    
    public LevelButton[] levelButtons;
	public int startLevelScene;
	public TextMeshProUGUI worldTitle;

	int sceneStartingNum = 0;
	int worldNum = 1;



	// Use this for initialization
	void Start () {
        levelButtons = GetComponentsInChildren<LevelButton>();
		SetNumbersForButtons(sceneStartingNum);
		worldTitle.text = "World " + worldNum.ToString();
	}


	public void SetNumbersForButtons(int startNum){
		for (int i = startNum; i < levelButtons.Length + startNum; i++)
		{
			levelButtons[i - startNum].SetLevelNumber(i + 1);
			levelButtons[i - startNum].SetSceneToButton(startLevelScene + i);

		}

	}
	


    void SetEveryButtonAboveToDisable(int levelNum) {
        for (int i = levelNum; i < 6; i++) {
            Button newButton = levelButtons[i].GetComponent<Button>();
            newButton.interactable = false;

        }

    }


	public void MoveForwardInWorlds(){
		sceneStartingNum += 20;
		SetNumbersForButtons(sceneStartingNum);

		worldNum++;
		worldTitle.text = "World " + worldNum.ToString();

	}

	public void MoveBackwardWorlds(){
		sceneStartingNum -= 20;
		SetNumbersForButtons(sceneStartingNum);

		worldNum--;
        worldTitle.text = "World " + worldNum.ToString();
	}


    

    
}
