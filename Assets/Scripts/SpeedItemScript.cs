using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItemScript : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime;
        if(this.transform.position.x <-9.5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().SpeedUpPlayer();
            Destroy(this.gameObject);
        }
    }

}
