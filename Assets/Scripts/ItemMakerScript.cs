using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMakerScript : MonoBehaviour
{
    public GameObject powerUp;      //연사력
    public GameObject HealingPotion; //체력
    public GameObject speedUp;      //이동속도

    float item_delay; //아이템 생성 주기
    float item_timer; //아이템 생성 시간
    //5초에 하나씩 생성

    void Start()
    {
        item_delay = 5;
        item_timer = 0;
    }
    void Update()
    {
        item_timer += Time.deltaTime;
        if(item_timer>=item_delay)
        {
            item_timer -= item_delay;
            float height = Random.Range(-4f, 3);//생성 위치
            int r = Random.Range(0,3);          //생성 아이템 선정
            if(r==1)
            {
                Instantiate(powerUp, new Vector3(9.8f, height, 0), Quaternion.identity);
            }
           else if (r ==0)
            {
                Instantiate(HealingPotion, new Vector3(9.8f, height, 0), Quaternion.identity);
            }
           else if (r == 2)
            {
                Instantiate(speedUp, new Vector3(9.8f, height, 0), Quaternion.identity);
            }
        }
    }
}
