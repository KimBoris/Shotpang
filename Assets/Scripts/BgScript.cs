using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    public float movingSpeed=2;//����̵��ӵ�
    public float movePos;//������ �������� �̵��ϴ� X��ǥ��
    public float limitPos;//������ �������� �Ǵ��ϴ� ������ǥ


    void Start()
    {

    }


    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime*movingSpeed;
        if(this.transform.position.x <= limitPos)
        {
            this.transform.position += Vector3.right * movePos;
        }
       
    }
}
