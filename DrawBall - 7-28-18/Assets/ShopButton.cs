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
    [HideInInspector]
	public Color startColor;

    private void Awake()
    {
        buttonImage = GetComponent<SVGImage>();
        startColor = buttonImage.color;
    }

    // Use this for initialization
    void Start () {


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




        if (isUnlocked == false)
        {
            // Locked it
            Color lockedColor = new Color(1, 1, 1, .25f);
            itemImage.color = lockedColor;
            buttonImage.color = lockedColor;

        }
        else {
            itemPrice.text = " ";

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
				buttonImage.color = Color.yellow;
                itemPrice.text = " ";
            }
			else
			{
				Debug.Log("Not Enough Money");
			}
		} else {

			Drawing_GameManager.currentPlayerBall = item.playerBall;
            buttonImage.color = Color.yellow;
		}


	}


    public void SetButtonColor() {
        if (Drawing_GameManager.currentPlayerBall == item.playerBall)
        {
            buttonImage.color = Color.yellow;
        }
        else {
            if (isUnlocked)
            {
                buttonImage.color = startColor;
            }
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
