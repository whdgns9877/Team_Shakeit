using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float timer = 0;
    private int yy = 0;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
      
        if (timer >= 2.5f)
        {
            yy++;

            rb.velocity = new Vector2(0, yy);
            timer = 0;
        }
        
    }
}
