using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPower : MonoBehaviour
{
    // ����
    public GameObject platform;
    // ������ ������Ʈ y��ǥ ����
    private int cnt = 0;
    // ������ x ��ǥ ����
    private int x = 0;

    [SerializeField] float jumpForce = 400f, speed = 5f, jumpZoneFoce = 2f;
    int jumpCount = 1;
    float moveX;

    bool isGround = false;
    bool isjumpZone = false;
    Rigidbody2D rb;


    private void OnCollisionEnter2D(Collision2D col)
    {
        // �±� �׶��忡 ������ ī���Ͱ� �ð� �׶��忡 ��´ٴ� �� 
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
            jumpCount = 1;
        }
        // �±� �������� ������ ���� Ʈ��
        if (col.gameObject.tag == "JumpZone")
        {
            isjumpZone = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //���� ī��Ʈ �ʱ�ȭ
        jumpCount = 0;
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {
        MoveMent();
    }

    // �����븦 ���� �ڵ�
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

    //�� ������ ���� �ڵ�
    public void CreateMap()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject gobj = Instantiate(platform);
            // Random ��ü�� �̿��ؼ� �������� x��ǥ�� �����ϰų� �����Ѵ�.
            if (Random.Range(0, 2) == 0) x++;
            else x--;
            gobj.transform.position = new Vector3(x, (++cnt), 0);
            // ������ ������Ʈ�� �����ϱ� ���� cnt�� ���� �־���.
            gobj.name = cnt.ToString();
        }
    }
}
