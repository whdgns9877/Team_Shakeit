using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMap : MonoBehaviour
{
    // ����
    public GameObject platform;
    // �� ����
    public GameObject platformUp;
    // Die ����
    public GameObject platformDown;
    // None ����
    public GameObject platformNone;

    // ������ ������Ʈ y��ǥ ����
    private int cnt = 0;
    // ������ x ��ǥ ����
    private int x = 0;

    // Start is called before the first frame update
    void Start()
    {     
        CreateMap();
    }

    //�� ������ ���� �ڵ�
    public void CreateMap()
    {
        for (int i = 0; i < 100; i++)
        {
            if (Random.Range(0, 7) == 0 || Random.Range(0, 7) == 1 || Random.Range(0, 7) == 2 || Random.Range(0, 7) == 3)
            {
                GameObject plat = Instantiate(platform);

                // Random ��ü�� �̿��ؼ� �������� x��ǥ�� �����ϰų� �����Ѵ�.
                if (Random.Range(0, 2) == 0)
                {
                    if (x >= 8) x--;

                    x++;
                }
                else
                {
                    if (x <= -8) x++;

                    x--;
                }
                plat.transform.position = new Vector3(x, (++cnt), 0);
                // ������ ������Ʈ�� �����ϱ� ���� cnt�� ���� �־���.
                plat.name = cnt.ToString();
            }
            else if(Random.Range(0,7) == 4)
            {
                GameObject upUp = Instantiate(platformUp);

                // Random ��ü�� �̿��ؼ� �������� x��ǥ�� �����ϰų� �����Ѵ�.
                if (Random.Range(0, 2) == 0)
                {
                    if (x >= 8) x--;
  
                    x++;
                }
                else
                {
                    if (x <= -8) x++;

                    x--;
                }
                    upUp.transform.position = new Vector3(x, (++cnt), 0);
                // ������ ������Ʈ�� �����ϱ� ���� cnt�� ���� �־���.
                upUp.name = cnt.ToString();
            }

            else if (Random.Range (0,7) == 5)
            {
                GameObject downDown = Instantiate(platformDown);

                // Random ��ü�� �̿��ؼ� �������� x��ǥ�� �����ϰų� �����Ѵ�.
                if (Random.Range(0, 2) == 0)
                {
                    if (x >= 8) x--;

                    x++;
                }
                else
                {
                    if (x <= -8) x++;

                    x--;
                }
                downDown.transform.position = new Vector3(x, (++cnt), 0);
                // ������ ������Ʈ�� �����ϱ� ���� cnt�� ���� �־���.
                downDown.name = cnt.ToString();
            }

            else if (Random.Range(0, 7) == 6)
            {
                GameObject none = Instantiate(platformNone);

                // Random ��ü�� �̿��ؼ� �������� x��ǥ�� �����ϰų� �����Ѵ�.
                if (Random.Range(0, 2) == 0)
                {
                    if (x >= 8) x--;

                    x++;
                }
                else
                {
                    if (x <= -8) x++;

                    x--;
                }
                none.transform.position = new Vector3(x, (++cnt), 0);
                // ������ ������Ʈ�� �����ϱ� ���� cnt�� ���� �־���.
                none.name = cnt.ToString();
            }
        }
    }
}
