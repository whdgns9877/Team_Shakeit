using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveMap : MonoBehaviour
{
    public float mapSpeed = 10f;
    public GameObject[] block;

    [SerializeField]
    GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstMap());
    }

    // Update is called once per frame
    void Update()
    {
        TransMap();
    }

    public void TransMap()
    {
        transform.Translate(Vector3.left * mapSpeed * Time.deltaTime);
    }

    public void OnEnable()
    {
        for (int i = 0; i < block.Length; i++)
        {
            if (Random.RandomRange(0, 3) == 0)
            {
                block[0].SetActive(true);
            }
            else
            {
                block[0].SetActive(false);
            }
        }
    }

    public IEnumerator InstMap()
    {
        while (true)
        {
            Instantiate(map);
        }

        yield return null;
    }
}
