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

    bool isHit;

    private void Start()
    {
        target = GameObject.FindObjectOfType<Player>().transform;   
    }
    private void Update()
    {
        moveVec = target.transform.position - transform.position;
        if (transform.position.y <= -30.0f) Destroy(gameObject);

        if (isHit) return;


        attackCooltimeLeft -= Time.deltaTime;
        waitTimeLeft -= Time.deltaTime;

        if (target == null || waitTimeLeft >= 0)
        {
            anim.SetBool("isMoving", false);
            return;
        }


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
                waitTimeLeft = 1.5f;
            }
        }
    }

    public void hit()
    {
        anim.SetTrigger("doHit");
        CO_DoHit();
        rb.AddForce(Vector2.right *  moveVec.normalized.x * -5f + Vector2.up * moveVec.normalized * 7f, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerAttack"))
        {
            hit();
        }
    }

    IEnumerator CO_DoHit()
    {
        isHit = true;
        yield return new WaitForSeconds(1.0f);
        isHit = false;
    }
}
