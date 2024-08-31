using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f; // 小球移动速度
    public float lifetime = 2f; // 小球存活时间（秒）
    private float timer = 0f; // 计时器
    private int direction;
    // Start is called before the first frame update
    // 设置玩家对象的引用
    public void SetDirection(int dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
