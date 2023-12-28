using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public LaunchingPad launchingPad;
    public GameObject room;

    public Transform idlePosition;

    private void Awake()
    {
        instance = this;
    }
}
