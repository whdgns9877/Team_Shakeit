using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;

    public Transform target;

    Vector3 moveVec;
    public float moveSpeed;

    bool isMove;


    private void Update()
    {
        if (target == null)
        {
            anim.SetBool("isMoving", false);
            return;
        }

        moveVec = target.transform.position - transform.position;
        anim.SetBool("isMoving", true);

        transform.position += new Vector3(moveVec.x, 0, 0).normalized * Time.deltaTime * moveSpeed;
       // transform.position += (moveVec.x > 0 ? 1 : -1) * Time.deltaTime * moveSpeed;

        if(moveVec.x >= 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            
        }

    }
}
