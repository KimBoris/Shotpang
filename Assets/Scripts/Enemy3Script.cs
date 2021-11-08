using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Script : EnemyMother
{

    float posNum;

    void Start()
    {
        eDir = Vector3.left;
        myscore = 4;
        enemyHp = 4;
        delay = 1.5f;
        enemySpeed = 3f;
        targetPos = GameObject.Find("Player");
        Bullet = Resources.Load<GameObject>("Prefabs/VioletFireBullet");
    }

    void Update()
    {
        posNum = Random.Range(1, 9);
        this.transform.position += eDir * Time.deltaTime * enemySpeed;
        if (targetPos != null)
        {
            makeBullet();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //랜덤으로 생성되는 벽에 부딫히면 위치 고정
        if (collision.tag == "e3collider")
        {
            eDir = Vector3.zero;
        }
    }

}
