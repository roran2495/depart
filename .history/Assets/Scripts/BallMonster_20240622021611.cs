using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMonster : MonoBehaviour
{
    private float speed = 30f;   // 小球移动速度
    private float lifetime = 1f; // 小球存活时间（秒）
    private float timer = 0f;    // 计时器
    private int direction;

    // 设置小球移动方向
    public void SetDirection(int dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void Update()
    {
        // 计时
        timer += Time.deltaTime;

        // 小球移动
        transform.Translate(direction * speed * Time.deltaTime, 0, 0);

        // 如果小球存活时间超过 lifetime，则销毁小球
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