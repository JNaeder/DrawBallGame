using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

	public GameObject pauseScreen, gameOver, winScreen;
	public TextMeshProUGUI gravityNum;


	public static float gravityMult;
	public float gravity;
	public Slider gravSlider;


	// Use this for initialization
	void Start()
	{
        Time.timeScale = 1;

		if(gravSlider != null){
			SetGravityLevel();

		}
	}

	// Update is called once per frame
	void Update()
	{
		gravity = gravityMult;
		Debug.Log(gravity + " " + gravityMult);
	}

	public void LoadScene(int sceneNum)
	{
		SceneManager.LoadScene(sceneNum);
		Time.timeScale = 1;
	}

    public void ResetBall() {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        gameOver.SetActive(false);
        winScreen.SetActive(false);

    }

	public void Pause()
	{
		Time.timeScale = 0;
		pauseScreen.SetActive(true);

	}

	public void UnPause()
	{
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
	}

    public void GameOverScreen() {
        Time.timeScale = 0;
        gameOver.SetActive(true);

    }

    public void WinScreen() {
        Time.timeScale = 0;
        winScreen.SetActive(true);

    }

    public void ReloadCurrentLevel() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

	public void SetGravityLevel(){
		gravSlider.value = LevelManager.gravityMult;
		Debug.Log(gravSlider.value);
		Debug.Log(LevelManager.gravityMult);
	}


	public void ChangeGravity(float newG){

		gravityMult = newG;
		gravityNum.text = newG.ToString("F2");

	}



}
