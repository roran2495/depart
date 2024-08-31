using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public float BoxSpeed = 200f; 
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 判断碰撞对象是否是 "Ball" 标签的游戏对象
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 向前移动
            rb.MovePosition(rb.position + Vector2.right * BoxSpeed * Time.fixedDeltaTime);
            Destroy(collision.gameObject);
        }
    }
}
