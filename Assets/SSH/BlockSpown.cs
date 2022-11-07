using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpown : MonoBehaviour
{
    [SerializeField]
    GameObject[] block;

    int Num = 0;

    private void Awake()
    {
        for (int i = 0; i < block.Length; i++)
        {
            block[i].SetActive(false);
        }
    }

    public void OnEnable()
    {
        SettingBlcok();
    }

    public void SettingBlcok()
    {
        Num = Random.RandomRange(0, 3);
        Debug.Log(Num);
        block[Num].SetActive(true);
    }
}
