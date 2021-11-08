using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : EnemyMother
{

    void Start()
    {
        eDir = Vector3.left;
        myscore = 5;
        enemyHp = 2;
        delay = 1.2f;
        enemySpeed = 6;
        this.GetComponent<Rigidbody2D>().AddForce(Vector3.left * enemySpeed, ForceMode2D.Impulse);
        //�ϴÿ��� �ڿ������� �������� �������� �� ���ش�
        Bullet = Resources.Load<GameObject>("Prefabs/Rock");
        targetPos = GameObject.Find("Player");
    }

    void Update()
    {
        //this.transform.position += eDir;    
        if (this.transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
        if (targetPos != null)
        {
            makeBullet();
        }
    }
}
