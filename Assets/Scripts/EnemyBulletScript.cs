using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    Vector3 bulletDir;//���ʹ� �ҷ��� �̵�����
    GameObject enemy1Bullet;//���ʹ� 1���� �ҷ�
    Transform PlayerPos; //�÷��̾� ��ġ
    string targetTag = "Player";//���ʹ� �ҷ��� Ÿ��
    public float enemyBulletSpeed;
    //���ʹ� �ҷ��� �ӵ� ���� �ٸ����� �ٰ��̱� ������
    public float enemyBulletLive;
    //�ҷ��� ����ִ� �ð�

    void Start()
    {
        PlayerPos = GameObject.Find(targetTag).GetComponent<Transform>();
        bulletDir = PlayerPos.position - this.transform.position;
        //�÷��̾ ���ؼ� 
        bulletDir = bulletDir.normalized;
        //������ �ӵ��� �����̰�
    }
    void Update()
    {
        //�Ѿ� ���� - �÷��̾��
        this.transform.position += bulletDir * Time.deltaTime * enemyBulletSpeed;
        //�Ѿ� �����ð�
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
        {//�÷��̾�� �浹�� �÷��̾� ���� ��ȯ�ϴ� �Լ� ȣ��
            collision.GetComponent<PlayerController>().call_Hit();
            Destroy(this.gameObject);//�Ѿ˵� ����
        }
    }
}
