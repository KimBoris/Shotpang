using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 dir = Vector3.up;//�������� ���ư����� ���Ⱚ�� �����ϴ� ����

    public float bulletSpeed = 12f;

    public GameObject bulletEff;//�浹�� ������ ����Ʈ

    string targetTag = "Enemy";//�ҷ��� �浹�� ����� �±װ�
                               //�ʱⰪ enemy

    void Start()
    {

    }

    void Update()
    {
        this.transform.position += dir * bulletSpeed * Time.deltaTime;
        if (this.transform.position.x > 9)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag || collision.tag == "Enemy3")
        {//targetTag = "Enemy"

            //���� (��)�� �ε�����
            Vector2 contactPoint = collision.ClosestPoint(this.transform.position);
            //ClosetPoint(�ε������) �ݶ��̴��� �浹�߻��� �浹���� ��ǥ ��ȯ

            //�Ѿ� �¾����� ����Ʈ�� ��ȯ���� ��ǥ���� ����
            GameObject eff = Instantiate(bulletEff, contactPoint, Quaternion.identity);
            Destroy(eff, 0.25f);

            //���ʹ� �ǰ�ó��
            collision.GetComponent<EnemyMother>().call_EHit();
            //���ʹ� �ǰݽ� �����Ÿ��� �ڷ�ƾ�Լ�
            Destroy(this.gameObject);//�Ѿ˵� ����
        }
    }

    public void setDir(Vector3 v)
    {
        dir = v;
    }
}
