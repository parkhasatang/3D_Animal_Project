using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public TMP_Text ScoreTxt;
    public Image[] HeartImg;
    private int remainHeart;

    public GameObject gameOverPopUp;
    public TMP_Text popUpBestScore;
    public TMP_Text popUpScore;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        remainHeart = HeartImg.Length;
    }

    public void AnimalHitGround()
    {
        if (remainHeart > 1)
        {
            HeartImg[remainHeart - 1].gameObject.SetActive(false);

            remainHeart--;
        }
        else
        {
            HeartImg[0].gameObject.SetActive(false);
            GameManager.instance.IsBestScore();
            GameManager.instance.GameOver();
            OpenGameOverPopUp();
        }
    }
    
    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.instance.PlayMusic("IntroBgm");
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void OpenGameOverPopUp()
    {
        AudioManager.instance.bgmSource.Stop();
        AudioManager.instance.PlaySFX("GameOver");
        gameOverPopUp.SetActive(true);
        popUpBestScore.text = $"{PlayerPrefs.GetInt("MyBestScore")}";
        popUpScore.text = $"{GameManager.instance.score}";
    }
}
