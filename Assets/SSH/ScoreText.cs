using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI TMP;

    private void Awake()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    public void ScoreTextInfo(int num)
    {
       TMP.text = num.ToString();
    }
}
