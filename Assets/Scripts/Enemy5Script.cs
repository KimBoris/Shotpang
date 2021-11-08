using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Script : EnemyMother
{

    //���ʹ� �ҷ�
    Vector3 Bdir = Vector3.left;
    GameObject Bosstarget;//�÷��̾� Ÿ�������ÿ� �̻��� �߻�



    void Start()
    {
        Bdir = Vector3.left;
        enemyHp = 100;
        myscore = 100;
        enemySpeed = 3.5f;
        Bosstarget = GameObject.Find("Player");
        Bullet = Resources.Load<GameObject>("Prefabs/BoneRingBullet");
        StartCoroutine(Fire());
    }


    void Update()
    {
        //������ ����� �������� �������� ����
        if (this.transform.position.x <= 5 && Bdir == Vector3.left)
        {
            Bdir = Vector3.up;
        }
        //���� ���� �Ϸ�� Y�� ��ǥ�� ���� �Ʒ����� ���� ��ȯ
        else if (this.transform.position.y >= 0.7)
        {
            Bdir = Vector3.down;
        }
        else if (this.transform.position.y < -4.6)
        {
            Bdir = Vector3.up;
        }

        this.transform.position += Bdir * enemySpeed * Time.deltaTime;
    }
    public IEnumerator Fire()
    {//�߻��� ������ �ֱ� ���� �ڷ�ƾ �Լ� ���
        if (Bosstarget != null)
        {
            //������ �������� �� 3�� 0.5���� ������ �ΰ� �߻��Ѵ�
            //�߻� �� 1���� ������ �ְ� �ٽ� 3���� �� �߻��Ѵ�
            while (true)// �����ִµ��� �ݺ������ֱ����� While�� ���
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject obj = Instantiate(Bullet, this.transform.position, Quaternion.identity);//Bullet�� �߻�
                    yield return new WaitForSeconds(0.2f);//0.2�ʿ� �ѹ߾� �߻�
                }
                yield return new WaitForSeconds(1f);//1���� ���� �ְ�
            }
        }
    }






}

