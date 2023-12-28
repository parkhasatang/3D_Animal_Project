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
            gameOverPopUp.SetActive(true);
        }
    }
    
    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
