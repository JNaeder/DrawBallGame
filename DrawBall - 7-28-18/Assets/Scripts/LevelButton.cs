using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour {

    Button button;

	public TextMeshProUGUI levelText;


	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();


		//levelText.gameObject.SetActive(false);      

	}


	public void SetLevelNumber(int num){
		levelText.text = num.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
