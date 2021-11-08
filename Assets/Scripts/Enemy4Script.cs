using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Script : EnemyMother
{

    void Start()
    {
        eDir = Vector3.left;
        myscore = 15;
        enemyHp = 10;
        enemySpeed = 3;
        delay = 2.5f;
        targetPos = GameObject.Find("Player");
        Bullet = Resources.Load<GameObject>("Prefabs/SpiritCore");
    }

  
    void Update()
    {
       //���ʹ̸� ������ ����´�
        this.transform.position += eDir * Time.deltaTime * enemySpeed;

        if (this.transform.position.x < -9.50)
        {
            Destroy(this.gameObject);
        }
        if (targetPos != null)
        {
            makeBullet();
        }
    }



}

