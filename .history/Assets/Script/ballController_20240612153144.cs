using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float speed = 10f; // 小球移动速度
    public float lifetime = 2f; // 小球存活时间（秒）
    private float timer = 0f; // 计时器
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        if (Player.position.x > transform.position.x)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
