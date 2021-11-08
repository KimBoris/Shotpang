using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMother : MonoBehaviour
{
    public GameObject targetPos;     //에너미 목적지
    
    protected GameObject Bullet;     //에너미 불렛
    protected int myscore;           //에너미가 가진 점수
    protected int enemyHp;           //에너미 체력

    protected float delay;           //에너미 불릿 딜레이
    protected float pressTime = 0;   //에너미 불렛발사시간
    protected float enemySpeed;      //에너미 이동 속도
    
    protected Vector3 eDir;          //에너미 이동방향
    protected Vector3 bDir;          //에너미 불렛의 이동방향


    void Start()
    {
        targetPos = GameObject.Find("Player");
    }
    void Update()
    {
        if (this.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
        makeBullet();

    }

    protected void makeBullet()
    {
        pressTime += Time.deltaTime;
        if (pressTime >= delay)
        {
            pressTime -= delay;
            GameObject obj = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        }
    }
    public void call_EHit()
    {
        StartCoroutine(Eishit());//객체 사라졌을때를 방지
    }

    //에너미가 피격당했을때
    public void Edamaged()
    {
        enemyHp--;//에너미 체력을 깎아준다
                  //에너미 체력이 0이하가 될때 점수를 올려주고
                  //에너미를 삭제해준다.
        if (enemyHp <= 0)
        {
            GameManager.instance.score += myscore;
            Destroy(this.gameObject);
        }
        //보스일 경우
        if (enemyHp <= 0 && this.gameObject.name == "Enemy5(Clone)")
        {
            //gm.GetComponent<GameManager>().StageClear();
            //스테이지 클리어 함수 
            GameManager.instance.StageClear();
        }
    }
    //에너미 피격시 깜빡거리는 효과
    public IEnumerator Eishit()
    {
        Edamaged();//피격당했을때 함수
        for (int i = 0; i <= 1; i++)
        {
            //스프라이트 렌더러를 껐다 켜준다.
            if (i % 2 == 0)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(0.02f);//0.02초 간격으로
        }
    }
}
