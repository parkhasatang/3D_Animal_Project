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

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        UiManager.instance.ScoreTxt.text = $"{score}";
    }
}
