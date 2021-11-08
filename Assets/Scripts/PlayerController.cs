using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;    //�÷��̾� �ҷ�
    public GameObject Hitmotion; //2D��������Ʈ �¾����� ���
    public GameObject Diemotion; //�׾����� ���
    public GameObject Idle;      //���� ���
    public GameObject RifleImage;//������ �̹��� ( �ǰݽ� ��ġ�� �ٲ�Ƿ� ���� ������Ʈ�� ���� )
    public GameObject[] LifeIcon;//������ ������UI
    public GameManager gm;

    Vector3 moveDir;//�÷��̾� �̵�����
    float moveH;//�����̵�
    float moveV;//�����̵�

    float speed = 7f;
    float delay;
    float pressTime = 0;

    public int hp = 3;

    bool hittable;//�ǰ� ���� ����

    void Start()
    {
        Bullet = Resources.Load<GameObject>("Prefabs/Bullet1");
        hittable = true;
        delay = 0.3f;//�Ѿ� �߻� ������ (�����̽� �� ���������� ��)
    }
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        moveDir = new Vector3(moveH, moveV, 0);
        //GetAxis�� �Է½� ��ü�� �ӵ��� ������ ��������/��������.
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
                //�����̽� �ٸ� ������ delay�ʸ��� �Ѿ� �߻�
                GameObject shot = Instantiate(Bullet, this.transform.position, Quaternion.identity);
                shot.GetComponent<BulletScript>().setDir(Vector3.right); //�Ѿ��� �߻� ����
                shot.transform.position += new Vector3(0.5f, 0.62f, 0);  //��ġ ����
            }
            //�����̽� �ٸ� ������ delay�ʸ��� �Ѿ��� �߻� ��.
            //�����̽��� ������ ���� ���ο� �Ѿ��� �����Ǵ� ���̴�.
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            pressTime = delay;
            //Ű���带 ���� ���� �����̸� �ʱ�ȭ�ؼ�
            //��� �Ѿ��� �߻�Ǵ� ���·� �ٲ��ش�.
        }
    }
    public void call_Hit()
    {
        StartCoroutine(isHit());
        //�ڷ�ƾ �Լ��� ������ 
        //�Լ��� �����Ų ��ü����
        //���ӵǱ� ������
        //�ش� ��ü�� �����Ǹ� �Լ��� ������ ���߿� �����ȴ�.
        //���� ����� �����Ǵ� �������
        //�������� �ʴ� ��󿡼� �Լ��� �θ����� ����� ���� ����.
    }

    //�ǰݽ� Ȱ��Ǵ� �Լ�
    public IEnumerator isHit()
    {
        if (hittable == true)
        {
            hp--;
            hittable = false;
            Idle.SetActive(false);

            if (hp < 0)
            {
                Idle.SetActive(false);//���� ��� ����
                Diemotion.SetActive(true);//�÷��̾� ���� ���
                yield return new WaitForSeconds(0.7f);
                gm.gameOverFunc();//���ӿ��� ȣ��
                Destroy(this.gameObject);//�÷��̾� ����
            }
            else
            {
                PlayerLife();//�÷��̾� ü�°��� �� �Ѿ� �߻�ӵ�, �̵��ӵ� �ʱ�ȭ
                //�ǰݽ� �����Ÿ��� ȿ��
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

    //�÷��̾� ������ ������
    public void PlayerLife()
    {
        LifeIcon[hp].SetActive(false);
        speed = 7f;//�ӵ� �ʱ�ȭ
        delay = 0.3f;//�Ѿ� �߻� �ӵ� �ʱ�ȭ
    }

    //�÷��̾� ü�� ���
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

    //�÷��̾� �߻� �ӵ� ����
    public void FireUpPlayer()
    {
        delay = 0.1f;   //�Ѿ� �߻� �ְ�ӵ� 0.1f�ʿ� 1��
    }
}
