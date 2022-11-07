using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPower : MonoBehaviour
{
    // 발판
    public GameObject platform;
    // 생성할 오브젝트 y좌표 설정
    private int cnt = 0;
    // 생성할 x 좌표 설정
    private int x = 0;

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
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {
        MoveMent();
    }

    // 점프대를 위한 코드
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

    //맵 생성을 위한 코드
    public void CreateMap()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject gobj = Instantiate(platform);
            // Random 객체를 이용해서 랜덤으로 x좌표를 증가하거나 감소한다.
            if (Random.Range(0, 2) == 0) x++;
            else x--;
            gobj.transform.position = new Vector3(x, (++cnt), 0);
            // 생성된 오브젝트를 구별하기 위해 cnt의 값을 넣어줌.
            gobj.name = cnt.ToString();
        }
    }
}
