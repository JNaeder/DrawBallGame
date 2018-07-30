using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour {

    Button button;

    public TextMeshProUGUI[] levelInfo; 


	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();


        if (!button.IsInteractable()) {
            foreach (TextMeshProUGUI t in levelInfo) {
                t.gameObject.SetActive(false);

            }

        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HideText()
    {
        foreach (TextMeshProUGUI t in levelInfo)
        {
            t.gameObject.SetActive(false);

        }


    } 
}
