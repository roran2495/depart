using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float speed = 10f; // 小球移动速度
    public float lifetime = 2f; // 小球存活时间（秒）
    private float timer = 0f; // 计时器
    private int direction;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        direction = player.position.x > transform.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
