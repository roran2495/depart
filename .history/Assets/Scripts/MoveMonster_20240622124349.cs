using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveMonster : MonoBehaviour
{
    [SerializeField] private GameObject[] routePoints; // �����ƶ������������յ㣩
    private int current = 0;
    [SerializeField] private float speed = 3f; // ���޵��ƶ��ٶ�
    private int direction = -1; // ���ڸ��ٹ��޵ĵ�ǰ����1 ��ʾ�����ƶ���-1 ��ʾ�����ƶ���
    public Slider MonsterSlider; // ��Unity�༭���й������޵�Ѫ��
    public TMP_Text Monsterblood;
    private int maxHealth = 100; // �������ֵ
    private int currentHealth;   // ��ǰ����ֵ
    public Camera mainCamera; // �����
    public Renderer monsterRenderer; // ��ɫ��Renderer

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        // ����Ѫ�����ɼ�
        MonsterSlider.gameObject.SetActive(false);
        Monsterblood.gameObject.SetActive(false);
        // ��ʼ��Ѫ��
        currentHealth = maxHealth;
        MonsterSlider.maxValue = maxHealth;
        MonsterSlider.value = currentHealth;
        Monsterblood.text = "AngryPig Blood : " + currentHealth + " / " + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsVisibleFrom(monsterRenderer, mainCamera)){
            // ����Ѫ���ɼ�
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

            // ��� direction Ϊ -1�����ɫ����X�ᷴת����� direction Ϊ 1�����ɫ������������
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
                // ����Ѫ�����ɼ�
                MonsterSlider.gameObject.SetActive(false);
                Monsterblood.gameObject.SetActive(false);
            }
        }
    }
}
