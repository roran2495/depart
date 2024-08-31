using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveMonster : MonoBehaviour
{
    [SerializeField] private GameObject[] routePoints; // 怪兽移动的区域（起点和终点）
    private int current = 0;
    [SerializeField] private float speed = 3f; // 怪兽的移动速度
    private int direction = -1; // 用于跟踪怪兽的当前方向。1 表示向右移动，-1 表示向左移动。
    public Slider MonsterSlider; // 在Unity编辑器中关联怪兽的血条
    public TMP_Text Monsterblood;
    private int maxHealth = 100; // 最大生命值
    private int currentHealth;   // 当前生命值
    public Camera mainCamera; // 摄像机
    public Renderer monsterRenderer; // 角色的Renderer

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        // 设置血条不可见
        MonsterSlider.gameObject.SetActive(false);
        Monsterblood.gameObject.SetActive(false);
        // 初始化血条
        currentHealth = maxHealth;
        MonsterSlider.maxValue = maxHealth;
        MonsterSlider.value = currentHealth;
        Monsterblood.text = "AngryPig Blood : " + currentHealth + " / " + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsVisibleFrom(monsterRenderer, mainCamera)){
            // 设置血条可见
            MonsterSlider.gameObject.SetActive(true);
            Monsterblood.gameObject.SetActive(true);
        }
        if(Vector2.Distance(routePoints[current].transform.position, transform.position) < .1f){
            current++;
            if(current >= routePoints.Length){
                current = 0;
            }
            if (routePoints[current].transform.position.x < transform.position.x)
            {
                direction = 1; // Moving right
            }else {
                direction = -1; // Moving left
            }

            // 如果 direction 为 -1，则角色将沿X轴反转；如果 direction 为 1，则角色保持正常方向。
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * direction;
            transform.localScale = localScale;
        }
        transform.position = Vector2.MoveTowards(transform.position, routePoints[current].transform.position, Time.deltaTime * speed);
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
            }
        }
    }
}
