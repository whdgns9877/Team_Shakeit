using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Inst { get { return instance; } }

    public int gameScore;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
    }

    public void AddScore(int score)
    {
        gameScore += score;
    }

    public void ResetScore()
    {
        gameScore = 0;
    }

    public void CheckBestScore()
    {

    }

    public void InitStartGame()
    {
        gameScore = 0;
    }
}
