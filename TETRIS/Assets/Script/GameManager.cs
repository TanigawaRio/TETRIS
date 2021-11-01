using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public int currentScore;
    public int clearScore = 1500;

    public Text timerText;
    public float gameTime = 60f;
    int seconds;

    public GameObject gamePauseUI;

    // Start is called before the first frame update
    void Start()
    {
        Intialize();
    }

    // Update is called once per frame
    void Update()
    {
        TimeManager();
    }

    private void Intialize()
    {
        score = 0;
    }

    public void TimeManager()
    {
        gameTime -= Time.deltaTime;
        seconds = (int)gameTime;
        timerText.text = seconds.ToString();

        if(seconds == 0)
        {
            Debug.Log("TimeOut");
            GameOver();
        }
    }

    public void AddScore()
    {
        score += 100;
        currentScore += score;
        scoreText.text = "Score : " + currentScore.ToString();

        Debug.Log(currentScore);

        if(currentScore >= clearScore)
        {
            GameClear();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }

    public void GamePause()
    {
        GamePauseToggle();
    }

    public void GamePauseToggle()
    {
        gamePauseUI.SetActive(!gamePauseUI.activeSelf);

        if(gamePauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
