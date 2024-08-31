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
        // �ж���ײ�����Ƿ��� "Ball" ��ǩ����Ϸ����
        if (collision.gameObject.CompareTag("Ball"))
        {
            // ��ǰ�ƶ�
            rb.MovePosition(rb.position + Vector2.right * BoxSpeed * Time.fixedDeltaTime);
            Destroy(collision.gameObject);
        }
    }
}
