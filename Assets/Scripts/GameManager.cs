using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public LaunchingPad launchingPad;
    public GameObject room;

    public Transform idlePosition;

    public int score;
    public int bestScore;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        UiManager.instance.ScoreTxt.text = $"{score}";
    }

    public void IsBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore") == false)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScore = score;
        }
        else
        {
            if (PlayerPrefs.GetInt("MyBestScore") < score)
            {
                PlayerPrefs.SetInt("MyBestScore", score);
                bestScore = score;
            }
            else
            {
                return;
            }
        }
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
    }
}
