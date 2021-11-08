using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMakerScript : MonoBehaviour
{
    public GameObject powerUp;      //�����
    public GameObject HealingPotion; //ü��
    public GameObject speedUp;      //�̵��ӵ�

    float item_delay; //������ ���� �ֱ�
    float item_timer; //������ ���� �ð�
    //5�ʿ� �ϳ��� ����

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
            float height = Random.Range(-4f, 3);//���� ��ġ
            int r = Random.Range(0,3);          //���� ������ ����
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
