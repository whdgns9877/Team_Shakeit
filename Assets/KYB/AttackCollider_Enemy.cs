using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider_Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //피격함수 불러오기
            Debug.Log("HIT");
            collision.GetComponent<Player>().Damage(1);
        }
    }
}
