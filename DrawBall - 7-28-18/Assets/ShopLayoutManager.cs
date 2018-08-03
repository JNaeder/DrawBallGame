using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class ShopLayoutManager : MonoBehaviour {


	public List<ShopItem> shopItems;
	ShopButton[] allButtons;

	// Use this for initialization
	void Start () {
		allButtons = GetComponentsInChildren<ShopButton>();
        


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
