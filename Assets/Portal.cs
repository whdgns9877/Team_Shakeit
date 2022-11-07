using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Scene_KYB")
                GameManager.Inst?.GoNextScene("JumpMap");
            else
                GameManager.Inst?.GoNextScene("SSH_Block");
        }
    }
}
