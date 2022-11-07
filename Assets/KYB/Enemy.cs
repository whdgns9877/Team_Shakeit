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

    public float waitTimeLeft;

    bool isMove;


    private void Start()
    {
        
    }
    private void Update()
    {
        attackCooltimeLeft -= Time.deltaTime;
        waitTimeLeft -= Time.deltaTime;

        if (target == null || waitTimeLeft >= 0)
        {
            anim.SetBool("isMoving", false);
            return;
        }

        moveVec = target.transform.position - transform.position;

        if (moveVec.x >= 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);

        }

        if (attackRange < Mathf.Abs(moveVec.x))
        {
            anim.SetBool("isMoving", true);
            transform.position += new Vector3(moveVec.x, 0, 0).normalized * Time.deltaTime * moveSpeed;


        }
        else
        {
            anim.SetBool("isMoving", false);

            if(attackCooltimeLeft <= 0)
            { 
                anim.SetTrigger("doAttack");
                attackCooltimeLeft = attackCooltime;
                waitTimeLeft = 2.0f;
            }
        }

    }

    public void hit()
    {
        Debug.Log("ENEMY HIT!");
        anim.SetTrigger("doHit");
    }
}
