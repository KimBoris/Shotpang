using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 dir = Vector3.up;//레이저가 날아가야할 방향값을 저장하는 변수

    public float bulletSpeed = 12f;

    public GameObject bulletEff;//충돌시 터지는 이펙트

    string targetTag = "Enemy";//불렛이 충돌할 대상의 태그값
                               //초기값 enemy

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

            //상대방 (적)과 부딪히면
            Vector2 contactPoint = collision.ClosestPoint(this.transform.position);
            //ClosetPoint(부딪힌대상) 콜라이더간 충돌발생시 충돌지점 좌표 반환

            //총알 맞았을때 이펙트를 반환받은 좌표에서 생성
            GameObject eff = Instantiate(bulletEff, contactPoint, Quaternion.identity);
            Destroy(eff, 0.25f);

            //에너미 피격처리
            collision.GetComponent<EnemyMother>().call_EHit();
            //에너미 피격시 깜빡거리는 코루틴함수
            Destroy(this.gameObject);//총알도 삭제
        }
    }

    public void setDir(Vector3 v)
    {
        dir = v;
    }
}
