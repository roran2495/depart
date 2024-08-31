using System.Collections.Generic;
using ClearSky;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private bool isPaused = false; // �ж���Ϸ�Ƿ���ͣ
    public GameObject canvas;
    public Transform player;
    public PlayerController playerController; // ����������ҿ������ű�
    private Vector3 initialPositionPlayer; // ��ɫ�ĳ�ʼλ��
    private Vector3 initialPositionCamera; // ����ĳ�ʼλ��
    public AudioSource clickSource;

    void Start() 
    {
        canvas.SetActive(false); // ����Ϸ��ʼʱ����UI Canvas����Ϊ���ɼ�
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanva(1);
        }     

    }

    // ���ڽ��ս�ɫ����������ĳ�ʼλ�ã��������Ǵ洢����Ӧ�ı�����
    public void GetInitialPosition(Vector3 position1, Vector3 position2){
        initialPositionPlayer = position1;
        initialPositionCamera = position2;
    }

    // ���������ť
    public void OnButtonContinueClick(){
        clickSource.Play();
        ToggleCanva(1);
    }

    // ������¿�ʼ��ť
    public void OnButtonRestartClick(){
        clickSource.Play();
        // ��ȡ��ǰ�����������
        string currentSceneName = SceneManager.GetActiveScene().name;
        // ���¼��ص�ǰ����
        SceneManager.LoadScene(currentSceneName);
        ToggleCanva(1);
    }

    // �����һ�ذ�ť
    public void OnButtonNextClick(){
        clickSource.Play();
        // ��ȡ��һ�������������
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        // ������һ������
        SceneManager.LoadScene(nextSceneIndex);
        ToggleCanva(1);
    }

    // ������ر���ҳ��ť
    public void OnButtonReturnClick(){
        clickSource.Play();
        SceneManager.LoadScene("Start");
    }
    
    // ����˳���ť
    public void OnButtonExitClick(){
        clickSource.Play();
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    
    public void ToggleCanva(int flag){
        canvas.SetActive(!canvas.activeSelf); // �л�UI Canvas�Ŀɼ���״̬
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // �л���Ϸʱ�����ţ�ʵ����ͣ�ͼ�������
        isPaused = !isPaused; // �л���Ϸ��ͣ״̬
        if (playerController != null){
            playerController.SetPaused(isPaused); // ����PlayerController�ű��е�SetPaused���������ݵ�ǰ��ͣ״̬
        }
        // ���ݲ���flag������"Exit"��ť�Ŀɼ���
        canvas.transform.Find("Exit").gameObject.SetActive(flag == 2 ? canvas.activeSelf : !canvas.activeSelf);
        // ���ݲ���flag������"Next Level"��ť�Ŀɼ���
        canvas.transform.Find("Next Level").gameObject.SetActive(flag == 3 ? canvas.activeSelf : !canvas.activeSelf);
    }

    // ���ٳ��������д��� "Ball" ��ǩ����Ϸ����
    private void DestroyBall(){
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }
}
