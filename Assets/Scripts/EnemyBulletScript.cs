using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    Vector3 bulletDir;//에너미 불렛의 이동방향
    GameObject enemy1Bullet;//에너미 1번의 불렛
    Transform PlayerPos; //플레이어 위치
    string targetTag = "Player";//에너미 불렛의 타겟
    public float enemyBulletSpeed;
    //에너미 불렛의 속도 각각 다른값을 줄것이기 때문에
    public float enemyBulletLive;
    //불렛이 살아있는 시간

    void Start()
    {
        PlayerPos = GameObject.Find(targetTag).GetComponent<Transform>();
        bulletDir = PlayerPos.position - this.transform.position;
        //플레이어를 향해서 
        bulletDir = bulletDir.normalized;
        //일정한 속도로 움직이게
    }
    void Update()
    {
        //총알 방향 - 플레이어에게
        this.transform.position += bulletDir * Time.deltaTime * enemyBulletSpeed;
        //총알 생존시간
        enemyBulletLive += Time.deltaTime;
        if (enemyBulletLive > 4)
        {
            enemyBulletLive = 0;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == targetTag)
        {//플레이어와 충돌시 플레이어 상태 변환하는 함수 호출
            collision.GetComponent<PlayerController>().call_Hit();
            Destroy(this.gameObject);//총알도 삭제
        }
    }
}
