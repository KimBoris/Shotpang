using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    Vector3 dir = Vector3.left;

    string targetTag = "Player";

    float bulletSpeed = 20; //�Ѿ� �߻� �ӵ�

    void Start()
    {

    }
    void Update()
    {
        this.transform.position += dir * Time.deltaTime * bulletSpeed;

        if (this.transform.position.x <= -9.2)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {//�÷��̾�� �浹�� �÷��̾� ���� ��ȯ�ϴ� �Լ� ȣ��
        if (collision.tag == targetTag)
        {
            collision.GetComponent<PlayerController>().call_Hit();
            Destroy(this.gameObject);//�Ѿ� ����
        }
    }


}
