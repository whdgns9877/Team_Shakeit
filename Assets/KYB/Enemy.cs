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
    public float attackRange;
    public float attackCooltime;
     float attackCooltimeLeft;


    bool isMove;


    private void Update()
    {
        attackCooltimeLeft -= Time.deltaTime;

        if (target == null)
        {
            anim.SetBool("isMoving", false);
            return;
        }

        moveVec = target.transform.position - transform.position;

        if (attackRange < Mathf.Abs(moveVec.x))
        {
            anim.SetBool("isMoving", true);
            transform.position += new Vector3(moveVec.x, 0, 0).normalized * Time.deltaTime * moveSpeed;
            if (moveVec.x >= 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);

            }
        }
        else
        {
            anim.SetBool("isMoving", false);

            if(attackCooltimeLeft <= 0)
            { 
                anim.SetTrigger("doAttack");
                attackCooltimeLeft = attackCooltime;
            }
        }

    }

    public void hit()
    {
        Debug.Log("ENEMY HIT!");
        anim.SetTrigger("doHit");
    }
}
