using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public bool isRight;
    private void OnCollisionStay2D(Collision2D collision)
    {
        collision.transform.Translate((isRight ? Vector2.right : Vector2.left) * Time.deltaTime * 3f);
    }
}
