using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGame : MonoBehaviour
{
    int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndScore(int Score)
    {
        
    }

    public IEnumerator ToTalScore (int Score)
    {
        totalScore += Score;

        if (totalScore >= 2000)
        {
            GameManager.Inst?.EndCurLevel();
        }
        yield return new WaitForSeconds(5f);

        GameManager.Inst?.ClearGame();
    }
}
