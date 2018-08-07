using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class ShopLayoutManager : MonoBehaviour {
	GameObject[] allPlayerBalls;

	ShopItem[] shopArray;
	List<ShopItem> shopItems;
	ShopButton[] allButtons;

	// Use this for initialization
	void Start () {
		allPlayerBalls = Resources.LoadAll<GameObject>("PlayerBalls");      
        foreach (GameObject g in allPlayerBalls)
        {
            string savedPlayerBall = PlayerPrefs.GetString("CurrentPlayerBall");
            if (g.name == savedPlayerBall)
            {
				Drawing_GameManager.currentPlayerBall = g;

            }
        }



		allButtons = GetComponentsInChildren<ShopButton>();
        
		shopArray = Resources.LoadAll<ShopItem>("ShopObjects");
		shopItems = new List<ShopItem>();
		foreach(ShopItem s in shopArray){
			shopItems.Add(s);
			Debug.Log(s.objectName);
		}


		shopItems.Sort(SortByPrice);



		for (int i = 0; i < shopItems.Count; i++){
			allButtons[i].item = shopItems[i];

            if (shopItems[i].playerBall == Drawing_GameManager.currentPlayerBall)
            {
                SVGImage newImage = allButtons[i].GetComponent<SVGImage>();
                newImage.color = Color.yellow;
                Debug.Log("Current Ball is " + Drawing_GameManager.currentPlayerBall);
                Debug.Log(shopItems[i]);

            }


		}
		
	}

	int SortByPrice(ShopItem item1, ShopItem item2){

		return item1.price.CompareTo(item2.price);

	}



    public void SetActiveBall() {
        for (int i = 0; i < shopItems.Count; i++) {
            allButtons[i].SetButtonColor();


        }


    }
}
