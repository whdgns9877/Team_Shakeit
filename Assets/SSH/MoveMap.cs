using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveMap : MonoBehaviour
{
    public float mapSpeed = 5f;

    [SerializeField]
    GameObject Map;

    private GameObject map;

    float X = 15f, Y = -4.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstMap());
    }

    public void TransMap()
    {
        map.transform.Translate(Vector3.left * mapSpeed * Time.deltaTime);
    }

    public IEnumerator InstMap()
    {
        while (true)
        {
            map = Instantiate(Map);
            map.transform.position = new Vector3(X,Y,0);
            yield return new WaitForSeconds(1.5f);
        }        
    }
}
