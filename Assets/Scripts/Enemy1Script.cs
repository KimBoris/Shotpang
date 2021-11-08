using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : EnemyMother
{

    void Start()
    {
        eDir = Vector3.left;
        myscore = 3;
        enemyHp = 3;
        enemySpeed = 4;
        delay = 2;
        targetPos = GameObject.Find("Player");
        Bullet = Resources.Load<GameObject>("Prefabs/GreenBubble");
    }

    void Update()
    {
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
