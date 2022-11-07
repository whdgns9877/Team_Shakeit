using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ClearGame : MonoBehaviour
{
    int totalScore = 0;
    GameObject scoreText;

    private void Awake()
    {
        scoreText = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
    }


    public IEnumerator ToTalScore (int Score)
    {
        totalScore += Score;

        scoreText.GetComponent<ScoreText>().ScoreTextInfo(totalScore);


        Debug.Log(totalScore);

        if (totalScore >= 2000)
        {
            GameManager.Inst?.EndCurLevel();
            GameManager.Inst?.ClearGame();
        }
        yield return null;
    }
}
