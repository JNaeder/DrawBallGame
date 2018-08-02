using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopLayoutManager : MonoBehaviour {


	public List<ShopItem> shopItems;
	ShopButton[] allButtons;

	// Use this for initialization
	void Start () {
		allButtons = GetComponentsInChildren<ShopButton>();


		shopItems.Sort(SortByPrice);
		for (int i = 0; i < shopItems.Count; i++){

			Debug.Log(shopItems[i].objectName);
			allButtons[i].item = shopItems[i];
		}
		
	}

	int SortByPrice(ShopItem item1, ShopItem item2){

		return item1.price.CompareTo(item2.price);

	}
}
