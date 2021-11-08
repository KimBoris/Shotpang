using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpeedUpScript : MonoBehaviour
{
    void Start()
    {
        
    }

    
    void Update()
    {//오브젝트 생성후 이동
        this.transform.position += Vector3.left * Time.deltaTime;
        if (this.transform.position.x < -9.5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//플레이어와 충돌시 해당 효과 적용
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().FireUpPlayer();
            Destroy(this.gameObject);
        }
    }
}
