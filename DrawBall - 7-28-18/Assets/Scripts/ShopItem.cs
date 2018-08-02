using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;

[CreateAssetMenu(fileName = "New ShopObject", menuName = "ShopObjects")]
public class ShopItem : ScriptableObject {

	public SVGAsset objectImage;
	public string objectName;
	public int price;
	public GameObject playerBall;


}
