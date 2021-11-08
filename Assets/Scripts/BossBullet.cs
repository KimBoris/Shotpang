using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    Vector3 dir = Vector3.left;

    string targetTag = "Player";

    float bulletSpeed = 20; //총알 발사 속도

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
    {//플레이어와 충돌시 플레이어 상태 변환하는 함수 호출
        if (collision.tag == targetTag)
        {
            collision.GetComponent<PlayerController>().call_Hit();
            Destroy(this.gameObject);//총알 삭제
        }
    }


}
