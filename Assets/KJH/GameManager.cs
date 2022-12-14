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
        if (instance != null)
            return;
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
        Debug.Log("EndCulLevel");
        TotalScore += gameScore;
        gameScore = 0;
    }

    public void ClearGame()
    {
        int curBestScore = TotalScore;
        bestScore = PlayerPrefs.GetInt("BestScore");

        if (curBestScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", curBestScore);
        }
        SceneManager.LoadScene("EndScene");
    }

    public void OnClickGameStart()
    {
        GoNextScene("Scene_KYB");
    }
}
