using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpeedUpScript : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {//������Ʈ ������ �̵�
        this.transform.position += Vector3.left * Time.deltaTime;
        if (this.transform.position.x < -9.5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//�÷��̾�� �浹�� �ش� ȿ�� ����
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().FireUpPlayer();
            Destroy(this.gameObject);
        }
    }
}
