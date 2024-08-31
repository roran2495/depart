using UnityEngine;

public class BarkController : MonoBehaviour
{
    public Transform rotationCenter; // 旋转中心

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 判断碰撞对象是否是 "Ball" 标签的游戏对象
        if (collision.tag == "Ball")
        {
            Log
            // 指定旋转角度为90度
            float angle = 90f;
            // 绕 rotationCenter 旋转
            transform.RotateAround(rotationCenter.position, Vector3.forward, angle);
        }
    }
}
