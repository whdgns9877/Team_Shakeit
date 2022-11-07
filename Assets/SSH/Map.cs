using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float mapSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveMap();
    }

    public void MoveMap()
    {
        transform.Translate(Vector3.left * mapSpeed * Time.deltaTime);
    }

}
