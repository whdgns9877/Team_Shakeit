using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    private void Awake()
    {

    }


    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
