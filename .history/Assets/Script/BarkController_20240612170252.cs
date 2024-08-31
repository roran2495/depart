using UnityEngine;

public class BarkController : MonoBehaviour
{
    public Transform rotationCenter; // 旋转中心

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 判断碰撞对象是否是 "Ball" 标签的游戏对象
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 指定旋转角度为90度
            float angle = 90f;
            // 绕 rotationCenter 旋转
            transform.RotateAround(rotationCenter.position, Vector3.forward, angle);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Ground")
            {
                anim.SetBool("isJump", false);
            }
            if (other.tag == "Die")
            {
                gameController.ToggleCanva(false);
            }
        }
}
