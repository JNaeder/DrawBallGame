using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    LevelManager lM;
    Drawing_GameManager dGM;

	// Use this for initialization
	void Start () {
        lM = FindObjectOfType<LevelManager>();
        dGM = FindObjectOfType<Drawing_GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathWall")
        {
            lM.GameOverScreen();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "Coin")
        {
            dGM.score++;
            dGM.currentCoinNum--;
            collision.gameObject.SetActive(false);
        }
    }
}
