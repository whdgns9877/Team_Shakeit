using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHP : MonoBehaviour
{
    int MaxHP = 0;
    public int curHP = 0;
    SpriteRenderer SR;

    [SerializeField] Sprite[] sprites;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        TransSprite();
    }

    private void OnEnable()
    {
        SR.sprite = sprites[0];

        if (gameObject.name == "LongBlock")
        {
            MaxHP = 3;
        }
        else if (gameObject.name == "MiddleBlock")
        {
            MaxHP = 2;
        }
        else if (gameObject.name == "SamllBlock")
        {
            MaxHP = 1;
        }
        else Debug.Log("Error");

        curHP = MaxHP;
    }

    private void TransSprite()
    {
        if (gameObject.name == "LongBlock")
        {
            if (curHP == 2)
            {
                SR.sprite = sprites[1];
            }
            else if (curHP == 1)
            {
                SR.sprite = sprites[2];
            }

            else if (curHP == 0)
            {
                Destroy(gameObject);
            }
        }

        else if (gameObject.name == "MiddleBlock")
        {
            if (curHP == 1)
            {
                SR.sprite = sprites[2];
            }

            else if (curHP == 0)
            {
                Destroy(gameObject);
            }
        }

        else if (gameObject.name == "SamllBlock")
        {
            if (curHP == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            Debug.Log("╬Нец");
            curHP -= 1;
            Debug.Log(curHP);
        }
    }
}
