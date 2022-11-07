using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMap : MonoBehaviour
{
    // 발판
    public GameObject platform;
    // 업 발판
    public GameObject platformUp;
    // Die 발판
    public GameObject platformDown;
    // None 발판
    public GameObject platformNone;

    // 생성할 오브젝트 y좌표 설정
    private int cnt = 0;
    // 생성할 x 좌표 설정
    private int x = 0;

    // Start is called before the first frame update
    void Start()
    {     
        CreateMap();
    }

    //맵 생성을 위한 코드
    public void CreateMap()
    {
        for (int i = 0; i < 100; i++)
        {
            if (Random.Range(0, 7) == 0 || Random.Range(0, 7) == 1 || Random.Range(0, 7) == 2 || Random.Range(0, 7) == 3)
            {
                GameObject plat = Instantiate(platform);

                // Random 객체를 이용해서 랜덤으로 x좌표를 증가하거나 감소한다.
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
                // 생성된 오브젝트를 구별하기 위해 cnt의 값을 넣어줌.
                plat.name = cnt.ToString();
            }
            else if(Random.Range(0,7) == 4)
            {
                GameObject upUp = Instantiate(platformUp);

                // Random 객체를 이용해서 랜덤으로 x좌표를 증가하거나 감소한다.
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
                // 생성된 오브젝트를 구별하기 위해 cnt의 값을 넣어줌.
                upUp.name = cnt.ToString();
            }

            else if (Random.Range (0,7) == 5)
            {
                GameObject downDown = Instantiate(platformDown);

                // Random 객체를 이용해서 랜덤으로 x좌표를 증가하거나 감소한다.
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
                // 생성된 오브젝트를 구별하기 위해 cnt의 값을 넣어줌.
                downDown.name = cnt.ToString();
            }

            else if (Random.Range(0, 7) == 6)
            {
                GameObject none = Instantiate(platformNone);

                // Random 객체를 이용해서 랜덤으로 x좌표를 증가하거나 감소한다.
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
                // 생성된 오브젝트를 구별하기 위해 cnt의 값을 넣어줌.
                none.name = cnt.ToString();
            }
        }
    }
}
