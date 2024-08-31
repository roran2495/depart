using UnityEngine;

public class BarkController : MonoBehaviour
{
    public Transform rotationCenter; // 旋转中心

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 判断碰撞对象是否是 "Player" 标签的游戏对象
        if (collision.gameObject.CompareTag("Player"))
        {
            // 指定旋转角度为90度
            float angle = 90f;
            // 绕 rotationCenter 旋转
            transform.RotateAround(rotationCenter.position, Vector3.forward, angle);
        }
    }
}