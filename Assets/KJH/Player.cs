using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState { Idle, Move, Jump, Dash}

    Rigidbody2D rb;
    Animator anim;

    [SerializeField] private float speed;

    bool isGround = false;
    bool isJump = true;

    bool canMove = false;
    bool isWalk = false;

    bool isAttack = false;
    bool flip = false;

    public int maxHp = 10;
    public int hp;

    public bool isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        if (isDead == true)
            return;

        CheckJump();

        if (isAttack == true)
            canMove = false;
        else
            canMove = true;

        if (isGround == true)
            isJump = true;
        else
            isJump = false;

        if (flip)
            transform.localScale = Vector3.one;
        else
            transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKeyDown(KeyCode.Z) && isAttack == false)
        {
            canMove = false;
            isAttack = true;

            if (isGround == true)
            {
                StartCoroutine(attack());
            }
            else
            {
                StartCoroutine(jumpAttack());
            }
        }
    }

    IEnumerator attack()
    {
        anim.SetTrigger("doAttack");
        yield return new WaitForSeconds(0.5f);
        canMove = true;
        isAttack = false;
    }

    IEnumerator jumpAttack()
    {
        anim.SetTrigger("doJumpAttack");
        yield return new WaitForSeconds(0.5f);
        canMove = true;
        isAttack = false;
    }

    private void FixedUpdate()
    {
        if (isDead == true)
            return;

        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("isMoving", true);
                isWalk = true;
                transform.position += Vector3.left * Time.fixedDeltaTime * speed;
                flip = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("isMoving", true);
                isWalk = true;
                transform.position += Vector3.right * Time.fixedDeltaTime * speed;
                flip = true;
            }
            else anim.SetBool("isMoving", false);
        }
        else
        {
            isWalk = false;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isJump && isGround)
        {
            rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
            anim.SetTrigger("doJump");
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            // 공중에서 아래로 찍기
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Up")
        {
            GameManager.Inst.AddScore(10);
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }

        else if (col.gameObject.tag == "SuperUp")
        {
            GameManager.Inst.AddScore(100);
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
        }

        else if (col.gameObject.tag == "Slow")
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
        }

        else if (col.gameObject.tag == "DeadZone")
        {
            Damage(10);
        }

    }

    private void CheckJump()
    {
        isGround = Physics2D.OverlapCircle(transform.position - Vector3.right * 0.2f, 0.03f, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.OverlapCircle(transform.position + Vector3.right * 0.2f, 0.05f, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("isGround", isGround);
    }

    public void Damage(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            Debug.Log("죽어쪙..");
            isDead = true;
        }
    }
}
