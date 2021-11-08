using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;    //플레이어 불렛
    public GameObject Hitmotion; //2D스프라이트 맞았을때 모션
    public GameObject Diemotion; //죽었을때 모션
    public GameObject Idle;      //평상시 모션
    public GameObject RifleImage;//라이플 이미지 ( 피격시 위치가 바뀌므로 따로 오브젝트를 뒀음 )
    public GameObject[] LifeIcon;//라이프 아이콘UI
    public GameManager gm;

    Vector3 moveDir;//플레이어 이동방향
    float moveH;//가로이동
    float moveV;//세로이동

    float speed = 7f;
    float delay;
    float pressTime = 0;

    public int hp = 3;

    bool hittable;//피격 가능 여부

    void Start()
    {
        Bullet = Resources.Load<GameObject>("Prefabs/Bullet1");
        hittable = true;
        delay = 0.3f;//총알 발사 딜레이 (스페이스 꾹 누르고있을 시)
    }
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        moveDir = new Vector3(moveH, moveV, 0);
        //GetAxis는 입력시 객체의 속도가 서서히 빨라지고/느려진다.
        this.transform.position += moveDir * Time.deltaTime * speed;
        PlayerFire();
    }

    void PlayerFire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pressTime += Time.deltaTime;
            if (pressTime >= delay)
            {
                pressTime -= delay;
                //스페이스 바를 누르면 delay초마다 총알 발사
                GameObject shot = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                shot.GetComponent<BulletScript>().setDir(Vector3.right); //총알의 발사 방향
                shot.transform.position += new Vector3(0.5f, 0.62f, 0);  //위치 조정
            }
            //스페이스 바를 누르면 delay초마다 총알이 발사 됨.
            //스페이스를 누를때 마다 새로운 총알이 생성되는 것이다.
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            pressTime = delay;
            //키보드를 떼는 순간 딜레이를 초기화해서
            //즉시 총알이 발사되는 상태로 바꿔준다.
        }
    }
    public void call_Hit()
    {
        StartCoroutine(isHit());
        //코루틴 함수의 실행은 
        //함수를 실행시킨 주체에게
        //종속되기 때문에
        //해당 주체가 삭제되면 함수의 실행이 도중에 정지된다.
        //따라서 대상이 삭제되는 구조라면
        //삭제되지 않는 대상에서 함수를 부르도록 만드는 편이 좋다.
    }

    //피격시 활용되는 함수
    public IEnumerator isHit()
    {
        if (hittable == true)
        {
            hp--;
            hittable = false;
            Idle.SetActive(false);

            if (hp < 0)
            {
                Idle.SetActive(false);//평상시 모션 해제
                Diemotion.SetActive(true);//플레이어 다이 모션
                yield return new WaitForSeconds(0.7f);
                gm.gameOverFunc();//게임오버 호출
                Destroy(this.gameObject);//플레이어 삭제
            }
            else
            {
                PlayerLife();//플레이어 체력감소 및 총알 발사속도, 이동속도 초기화
                //피격시 깜빡거리는 효과
                for (int i = 0; i <= 20; i++)
                {
                    if (i % 2 == 0)
                    {
                        this.Hitmotion.SetActive(false);
                        this.RifleImage.SetActive(false);
                    }
                    else
                    {
                        this.Hitmotion.SetActive(true);
                        this.RifleImage.SetActive(true);
                    }
                    yield return new WaitForSeconds(0.1f);
                }
                this.Idle.SetActive(true);
                hittable = true;
                yield return null;
            }
        }
    }

    //플레이어 라이프 아이콘
    public void PlayerLife()
    {
        LifeIcon[hp].SetActive(false);
        speed = 7f;//속도 초기화
        delay = 0.3f;//총알 발사 속도 초기화
    }

    //플레이어 체력 상승
    public void HealPlayer()
    {
        hp += 1;
        if (hp > 3)//Max Hp = 3
        {
            hp = 3;
        }
        LifeIcon[hp - 1].SetActive(true);
    }
    public void SpeedUpPlayer()
    {
        speed = 10f;
        if (speed >= 10)//Max Speed = 10
        {
            speed = 10;
        }
    }

    //플레이어 발사 속도 증가
    public void FireUpPlayer()
    {
        delay = 0.1f;   //총알 발사 최고속도 0.1f초에 1발
    }
}
