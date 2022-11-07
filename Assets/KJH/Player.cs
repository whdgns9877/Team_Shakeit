using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState { Idle, Move, Jump, Dash}

    Rigidbody2D rb;

    [SerializeField] private float speed;

    bool isGround = false;
    bool isJump = true;

    bool flip = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckJump();

        if (isGround == true)
            isJump = true;
        else
            isJump = false;

        if (flip)
            transform.localScale = Vector3.one;
        else
            transform.localScale = new Vector3(-1,1,1);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.fixedDeltaTime * speed;
            flip = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.fixedDeltaTime * speed;
            flip = true;
        }


        if (Input.GetKey(KeyCode.UpArrow) && isJump && isGround)
        {
            rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            // 공중에서 아래로 찍기
        }
    }

    private void CheckJump()
    {
        isGround = Physics2D.OverlapCircle(transform.position - Vector3.right * 0.2f, 0.03f, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.OverlapCircle(transform.position + Vector3.right * 0.2f, 0.05f, 1 << LayerMask.NameToLayer("Ground"));
    }
}
