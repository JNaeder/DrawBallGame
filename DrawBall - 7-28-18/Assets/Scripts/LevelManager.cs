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

	public bool isPaused;


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
	}

	public void LoadScene(int sceneNum)
	{
		
		Time.timeScale = 1;
		if (pauseScreen != null)
		{
			pauseScreen.SetActive(false);
			gameOver.SetActive(false);
			winScreen.SetActive(false);
		}
		SceneManager.LoadScene(sceneNum);
	}

    public void ResetBall() {
        Time.timeScale = 1;
		isPaused = false;
        pauseScreen.SetActive(false);
        gameOver.SetActive(false);
        winScreen.SetActive(false);

    }

	public void Pause()
	{
		Time.timeScale = 0;
		pauseScreen.SetActive(true);
		isPaused = true;

	}

	public void UnPause()
	{
		Time.timeScale = 1;
		isPaused = false;
		pauseScreen.SetActive(false);
	}

    public void GameOverScreen() {
        Time.timeScale = 0;
		isPaused = true;
        gameOver.SetActive(true);

    }

    public void WinScreen() {
        Time.timeScale = 0;
		isPaused = true;
        winScreen.SetActive(true);

    }

    public void ReloadCurrentLevel() {
		isPaused = false;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

	public void SetGravityLevel(){
		gravSlider.value = LevelManager.gravityMult;
	}


	public void ChangeGravity(float newG){

		gravityMult = newG;
		gravityNum.text = newG.ToString("F2");

	}

	public void GoToNextLevel(){
		int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
		SceneManager.LoadScene(nextScene);

	}



}
