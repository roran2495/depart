using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMonster : MonoBehaviour
{
    private float speed = 30f;   // С���ƶ��ٶ�
    private float lifetime = 1f; // С����ʱ�䣨�룩
    private float timer = 0f;    // ��ʱ��
    private int direction;

    // ����С���ƶ�����
    public void SetDirection(int dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void Update()
    {
        // ��ʱ
        timer += Time.deltaTime;

        // С���ƶ�
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

        // ���С����ʱ�䳬�� lifetime��������С��
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ball"){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}