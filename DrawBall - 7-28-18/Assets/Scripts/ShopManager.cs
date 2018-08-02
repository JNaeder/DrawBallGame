using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour {

	public TextMeshProUGUI moneyNumText;

	public static int moneyNum = 0;


	ShopButton[] allShopButtons;

	// Use this for initialization
	void Start () {

		moneyNum = PlayerPrefs.GetInt("Money");
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUIStuff();
		
	}


	void UpdateUIStuff(){
		moneyNumText.text = moneyNum.ToString();

	}

	public void ResetMoney(){
		moneyNum = 0;
		PlayerPrefs.SetInt("Money", moneyNum);

			

	}


	public void ResetStore(){
		allShopButtons = FindObjectsOfType<ShopButton>();
		foreach(ShopButton s in allShopButtons){
			s.GetLocked();
		}

	}
}
