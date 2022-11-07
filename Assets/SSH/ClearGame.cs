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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator ToTalScore (int Score)
    {
        totalScore += Score;

        scoreText.GetComponent<ScoreText>().ScoreTextInfo(totalScore);

        //ScoreText.sco = totalScore.ToString();

        Debug.Log(totalScore);

        if (totalScore >= 2000)
        {
            GameManager.Inst?.EndCurLevel();
        }
        yield return new WaitForSeconds(5f);

        GameManager.Inst?.ClearGame();
    }
}
