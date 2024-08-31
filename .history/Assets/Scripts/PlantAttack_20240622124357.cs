using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantAttack : MonoBehaviour
{
    private float timer = 0f;     // ��ʱ����ʼֵ
    private float waittime = 1f;  // �ȴ�ʱ�䣬ÿ��1������һ��С��
    private int direction = -1;    // �ƶ�����
    public GameObject ballPrefab; // С��Ԥ����
    public Slider MonsterSlider; // ��Unity�༭���й������޵�Ѫ��
    public TMP_Text Monsterblood;
    private int maxHealth = 100; // �������ֵ
    private int currentHealth;   // ��ǰ����ֵ
    public Camera mainCamera; // �����
    public Renderer monsterRenderer; // ��ɫ��Renderer
    private bool IsAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f; // ��ʼ����ʱ��
        mainCamera = Camera.main;
        // ����Ѫ�����ɼ�
        MonsterSlider.gameObject.SetActive(false);
        Monsterblood.gameObject.SetActive(false);
        // ��ʼ��Ѫ��
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
            // ���ü�ʱ��
            timer = 0f;
            // ����С������λ��
            Vector3 positionTmp = new Vector3(transform.position.x, transform.position.y, 0);
            // ʵ����С��Ԥ����
            GameObject newBall = Instantiate(ballPrefab, positionTmp, Quaternion.identity);
            // ��ȡ BallMonster ��������÷���
            BallMonster ballMonster = newBall.GetComponent<BallMonster>();
            ballMonster.SetDirection(direction);
        }
        if (IsVisibleFrom(monsterRenderer, mainCamera)){
            // ����Ѫ���ɼ�
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
                // ����Ѫ�����ɼ�
                MonsterSlider.gameObject.SetActive(false);
                Monsterblood.gameObject.SetActive(false);
                IsAttack = false; // ֹͣ����
            }
        }
    }
}
