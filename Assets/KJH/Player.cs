using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState { Idle, Move, Jump, Dash}

    Rigidbody2D rb;

    private float defaultSpeed;

    bool isGround = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        rb.AddForce(Vector2.right * v, ForceMode2D.Impulse);

        //if (rb.velocity.x > maxSpeed)
        //    rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        //else if(rb.velocity.x < maxSpeed * -1f)
        //    rb.velocity = new Vector2(maxSpeed * -1f, rb.velocity.y);
    }

    private void CheckJump()
    {
        isGround = Physics2D.OverlapCircle(transform.position - Vector3.right * 0.2f, 0.03f, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.OverlapCircle(transform.position + Vector3.right * 0.2f, 0.05f, 1 << LayerMask.NameToLayer("Ground"));
    }
}
