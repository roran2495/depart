using UnityEngine;

public class BarkController : MonoBehaviour
{
    public Transform rotationCenter; // 旋转中心

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 输出碰撞对象的信息
        Debug.Log($"Collision with {collision.gameObject.name}, Tag: {collision.gameObject.tag}");

        // 判断碰撞对象是否是 "Ball" 标签的游戏对象
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball collision detected");

            // 指定旋转角度为90度
            float angle = 90f;

            // 绕 rotationCenter 旋转
            if (rotationCenter != null)
            {
                transform.RotateAround(rotationCenter.position, Vector3.forward, angle);
                Debug.Log("Bark rotated around the rotation center");
            }
            else
            {
                Debug.LogWarning("Rotation center is not assigned!");
            }
        }
    }
}

