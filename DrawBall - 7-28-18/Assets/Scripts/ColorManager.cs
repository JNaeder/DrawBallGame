using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ColorManager : MonoBehaviour {

    public GameObject[] color1Objects;
    public Color color1Color = Color.white;
    public GameObject[] color2Objects;
    public Color color2Color = Color.white;
    public GameObject[] color3Objects;
    public Color color3Color = Color.white;
    public GameObject[] color4Objects;
    public Color color4Color = Color.white;
    public GameObject[] color5Objects;
    public Color color5Color = Color.white;


    // Use this for initialization
    void Start () {
        ChangeColorToObjects(color1Objects, color1Color);
        ChangeColorToObjects(color2Objects, color2Color);
        ChangeColorToObjects(color3Objects, color3Color);
        ChangeColorToObjects(color4Objects, color4Color);
        ChangeColorToObjects(color5Objects, color5Color);




    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeColorToObjects(GameObject[] objects, Color color) {

        foreach (GameObject g in objects) {
            SpriteRenderer sP = g.GetComponent<SpriteRenderer>();
            Camera cam = g.GetComponent<Camera>();
            Button button = g.GetComponent<Button>();
            Image image = g.GetComponent<Image>();
            TextMeshProUGUI tMP = g.GetComponent<TextMeshProUGUI>();
            Text newText = g.GetComponent<Text>();


            if (sP != null)
            {
                sP.color = color;
            }
            else if (cam != null)
            {
                cam.backgroundColor = color;
            }
            else if (button != null)
            {
                ColorBlock newButton = button.colors;
                newButton.normalColor = color;
                button.colors = newButton;
            }
            else if (tMP != null)
            {
                tMP.color = color;
            }
            else if (image != null)
            {
                image.color = color;
            }
            else if (newText != null) {
                newText.color = color;

            }




        }



    }
}
