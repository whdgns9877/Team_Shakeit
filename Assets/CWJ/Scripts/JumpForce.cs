using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForce : MonoBehaviour
{
    // 점프 코드
    [SerializeField] float jumpForce = 400f, speed = 5f, jumpZoneFoce = 2f;
    int jumpCount = 1;
    float moveX;

    bool isGround = false;
    bool isjumpZone = false;
    Rigidbody2D rb;


    private void OnCollisionEnter2D(Collision2D col)
    {
        // 태그 그라운드에 닿으면 카운터가 늘고 그라운드에 닿는다는 뜻 
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
            jumpCount = 1;
        }
        // 태그 점프좀에 닿으면 존이 트루
        if (col.gameObject.tag == "JumpZone")
        {
            isjumpZone = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //점프 카운트 초기화
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveMent();
    }

    void MoveMent()
    {
        if (isGround)
        {
            if (jumpCount > 0)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector2.up * jumpForce);
                    jumpCount--;
                }
            }

            if (isjumpZone)
            {
                rb.AddForce(new Vector2(0, jumpZoneFoce) * jumpForce);
                isjumpZone = false;
            }
        }

        moveX = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);
    }

}
