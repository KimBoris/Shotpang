using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    public float movingSpeed=2;//배경이동속도
    public float movePos;//밖으로 나갔을때 이동하는 X좌표값
    public float limitPos;//밖으로 나갔는지 판단하는 기준좌표


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
