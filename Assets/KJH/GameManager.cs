using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Inst { get { return instance; } }

    public int TotalScore;
    public int gameScore;
    public int bestScore;

    public GameObject player;

    public int curLevel = 0;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        gameScore = 0;
    }

    public void AddScore(int score)
    {
        gameScore += score;
    }

    public void GoNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void InitStartGame(int curLevel)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        switch (curLevel)
        {
            case 1:
                break;

            case 2:
                break;
        }
    }

    public void EndCurLevel()
    {
        TotalScore += gameScore;
        gameScore = 0;
    }

    public void ClearGame()
    {
        Debug.Log("³¡");
        int curBestScore = TotalScore;
        bestScore = PlayerPrefs.GetInt("BestScore");

        if (curBestScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", curBestScore);
        }
    }

    public void OnClickGameStart()
    {
        GoNextScene("Scene_KYB");
    }
}
