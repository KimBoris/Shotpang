using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e3collider : MonoBehaviour
{
    //���ʹ� 3�� �����ʿ��� �������� �̵��ϴ� 
    //�� ������Ʈ�� �浹�� ���ڸ��� �����
    float Xnum; //������Ʈ X�� ��ǥ��

    public GameObject E3collider; 

    //private BoxCollider2D boxC;

    public Vector3 Cpos;

    void Start()
    {
        Cpos = new Vector3(Xnum, 0, 0);
       // boxC = this.gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy3")
        {//���ʹ� 3��(�����) �� �浹�� ���ο� ��ġ�� ������Ű�� �� ����
            ColliderWallSet();
        }
    }
    void ColliderWallSet()
    {
        Xnum = Random.Range(1f, 7f);
        this.transform.position = new Vector3(Xnum, 0, 0);
    }
}
