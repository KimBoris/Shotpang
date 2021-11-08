using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e3collider : MonoBehaviour
{
    //에너미 3가 오른쪽에서 왼쪽으로 이동하다 
    //이 오브젝트와 충돌시 제자리에 멈춘다
    float Xnum; //오브젝트 X값 좌표값

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
        {//에너미 3번(보라색) 과 충돌시 새로운 위치에 정지시키는 벽 생성
            ColliderWallSet();
        }
    }
    void ColliderWallSet()
    {
        Xnum = Random.Range(1f, 7f);
        this.transform.position = new Vector3(Xnum, 0, 0);
    }
}
