using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public GameObject pauseScreen, gameOver, winScreen;

	// Use this for initialization
	void Start()
	{
        Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update()
	{

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



}
