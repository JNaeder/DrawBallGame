using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;
using TMPro;

public class ShopButton : MonoBehaviour {
   

	public ShopItem item;

	public SVGImage itemImage;
	public TextMeshProUGUI itemPrice;
	public bool isUnlocked;

	SVGImage buttonImage;
	Color startColor;



	// Use this for initialization
	void Start () {
		buttonImage = GetComponent<SVGImage>();
		startColor = buttonImage.color;


		if (item != null)
		{
			itemImage.vectorGraphics = item.objectImage;
			itemPrice.text = item.price.ToString();
			if (PlayerPrefs.GetInt(item.name) == 1)
            {
                isUnlocked = true;
            }
            else
            {
                isUnlocked = false;
            }
		} else {
			isUnlocked = false;
			itemPrice.text = " ";

		}




		if(isUnlocked ==  false){
			// Locked it
			Color lockedColor = new Color(1, 1, 1, .25f);
			itemImage.color = lockedColor;
			buttonImage.color = lockedColor;

		}
		
	}
	

	public void SetPlayerBall(){
		if (!isUnlocked)
		{

			if (ShopManager.moneyNum >= item.price)
			{
				ShopManager.moneyNum -= item.price;
				PlayerPrefs.SetInt("Money", ShopManager.moneyNum);
				Drawing_GameManager.currentPlayerBall = item.playerBall;
				isUnlocked = true;
				PlayerPrefs.SetInt(item.objectName, 1);
				itemImage.color = Color.white;
				buttonImage.color = startColor;

			}
			else
			{
				Debug.Log("Not Enough Money");
			}
		} else {

			Drawing_GameManager.currentPlayerBall = item.playerBall;

		}


	}


	public void GetLocked()
	{
		if (item != null)
		{
			isUnlocked = false;
			PlayerPrefs.SetInt(item.objectName, 0);
			Color lockedColor = new Color(1, 1, 1, .25f);
			itemImage.color = lockedColor;
			buttonImage.color = lockedColor;
		}
	}
}
