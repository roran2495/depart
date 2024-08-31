using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkController : MonoBehaviour
{
    public Transform rotationCenter; // 旋转中心
    public float rotationSpeed = 50f; // 旋转速度

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 判断碰撞对象是否是 "Player" 标签的游戏对象
        if (collision.gameObject.CompareTag("Player"))
        {
            // 计算旋转角度
            float angle = rotationSpeed * Time.deltaTime;
            // 绕 rotationCenter 旋转
            transform.RotateAround(rotationCenter.position, Vector3.forward, angle);
        }
    }
}
