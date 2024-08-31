using UnityEngine;

public class ballController : MonoBehaviour
{
    public float speed = 10f; // 小球移动速度
    public float lifetime = 2f; // 小球存活时间（秒）
    private float timer = 0f; // 计时器
    private int direction;
    public Transform player;
    // Start is called before the first frame update
    // 设置玩家对象的引用
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
        // 根据玩家的位置决定小球移动方向
        direction = player.position.x > transform.position.x ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 计时
        timer += Time.deltaTime;
        // 小球移动
        transform.Translate(direction * speed * Time.deltaTime,transform.position.y,transform.position.z);
        // 如果小球存活时间超过 lifetime，则销毁小球
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
