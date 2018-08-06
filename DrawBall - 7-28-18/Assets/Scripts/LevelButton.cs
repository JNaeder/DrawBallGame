using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    Button button;

	public TextMeshProUGUI levelText;


	// Use this for initialization
	void Start () {
        


		//levelText.gameObject.SetActive(false);      

	}


	public void SetLevelNumber(int num){
		levelText.text = num.ToString();

	}

	public void SetSceneToButton(int i){
		button = GetComponent<Button>();
		button.onClick.AddListener(delegate { LoadScene(i); });

	}


	void LoadScene(int sceneNum){
		Debug.Log("Load Scene " + sceneNum);
		SceneManager.LoadScene(sceneNum);
	}

    
}
