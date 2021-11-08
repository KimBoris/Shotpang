using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMother : MonoBehaviour
{
    public GameObject targetPos;     //���ʹ� ������
    
    protected GameObject Bullet;     //���ʹ� �ҷ�
    protected int myscore;           //���ʹ̰� ���� ����
    protected int enemyHp;           //���ʹ� ü��

    protected float delay;           //���ʹ� �Ҹ� ������
    protected float pressTime = 0;   //���ʹ� �ҷ��߻�ð�
    protected float enemySpeed;      //���ʹ� �̵� �ӵ�
    
    protected Vector3 eDir;          //���ʹ� �̵�����
    protected Vector3 bDir;          //���ʹ� �ҷ��� �̵�����


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
        StartCoroutine(Eishit());//��ü ����������� ����
    }

    //���ʹ̰� �ǰݴ�������
    public void Edamaged()
    {
        enemyHp--;//���ʹ� ü���� ����ش�
                  //���ʹ� ü���� 0���ϰ� �ɶ� ������ �÷��ְ�
                  //���ʹ̸� �������ش�.
        if (enemyHp <= 0)
        {
            GameManager.instance.score += myscore;
            Destroy(this.gameObject);
        }
        //������ ���
        if (enemyHp <= 0 && this.gameObject.name == "Enemy5(Clone)")
        {
            //gm.GetComponent<GameManager>().StageClear();
            //�������� Ŭ���� �Լ� 
            GameManager.instance.StageClear();
        }
    }
    //���ʹ� �ǰݽ� �����Ÿ��� ȿ��
    public IEnumerator Eishit()
    {
        Edamaged();//�ǰݴ������� �Լ�
        for (int i = 0; i <= 1; i++)
        {
            //��������Ʈ �������� ���� ���ش�.
            if (i % 2 == 0)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(0.02f);//0.02�� ��������
        }
    }
}
