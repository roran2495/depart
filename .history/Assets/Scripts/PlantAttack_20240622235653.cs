using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantAttack : MonoBehaviour
{
    private float timer = 0f;     // 计时器初始值
    private float waittime = 1f;  // 等待时间，每隔1秒生成一个小球
    private int direction = -1;    // 移动方向
    public GameObject ballPrefab; // 小球预制体
    public Slider MonsterSlider; // 在Unity编辑器中关联怪兽的血条
    public TMP_Text Monsterblood;
    private int maxHealth = 100; // 最大生命值
    private int currentHealth;   // 当前生命值
    public Camera mainCamera; // 摄像机
    public Renderer monsterRenderer; // 角色的Renderer
    private bool IsAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f; // 初始化计时器
        mainCamera = Camera.main;
        // 设置血条不可见
        MonsterSlider.gameObject.SetActive(false);
        Monsterblood.gameObject.SetActive(false);
        // 初始化血条
        currentHealth = maxHealth;
        MonsterSlider.maxValue = maxHealth;
        MonsterSlider.value = currentHealth;
        Monsterblood.text = "Plant Blood : " + currentHealth + " / " + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waittime && IsAttack)
        {
            // 重置计时器
            timer = 0f;
            // 计算小球生成位置
            Vector3 positionTmp = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
            // 实例化小球预制体
            GameObject newBall = Instantiate(ballPrefab, positionTmp, Quaternion.identity);
            // 获取 BallMonster 组件并设置方向
            BallMonster ballMonster = newBall.GetComponent<BallMonster>();
            ballMonster.SetDirection(direction);
        }
        if (IsVisibleFrom(monsterRenderer, mainCamera)){
            // 设置血条可见
            MonsterSlider.gameObject.SetActive(true);
            Monsterblood.gameObject.SetActive(true);
        }
    }

    bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ball"){
            currentHealth -= 20;
            MonsterSlider.value = currentHealth;
            Monsterblood.text = "AngryPig Blood : " + currentHealth + " / " + maxHealth;
            Destroy(collision.gameObject);
            if(currentHealth <= 0){
                Destroy(gameObject);
                // 设置血条不可见
                MonsterSlider.gameObject.SetActive(false);
                Monsterblood.gameObject.SetActive(false);
                IsAttack = false; // 停止攻击
            }
        }
    }
}
