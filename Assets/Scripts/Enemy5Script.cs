using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Script : EnemyMother
{

    //에너미 불렛
    Vector3 Bdir = Vector3.left;
    GameObject Bosstarget;//플레이어 타겟있을시에 미사일 발사



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
        //보스가 입장시 우측에서 좌측으로 출현
        if (this.transform.position.x <= 5 && Bdir == Vector3.left)
        {
            Bdir = Vector3.up;
        }
        //보스 입장 완료시 Y축 좌표를 통해 아래위로 방향 전환
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
    {//발사의 간격을 주기 위해 코루틴 함수 사용
        if (Bosstarget != null)
        {
            //보스의 레이저는 총 3발 0.5초의 간격을 두고 발사한다
            //발사 후 1초의 간격을 주고 다시 3발을 재 발사한다
            while (true)// 살이있는동안 반복시켜주기위해 While문 사용
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject obj = Instantiate(Bullet, this.transform.position, Quaternion.identity);//Bullet을 발사
                    yield return new WaitForSeconds(0.2f);//0.2초에 한발씩 발사
                }
                yield return new WaitForSeconds(1f);//1초의 텀을 주고
            }
        }
    }






}

