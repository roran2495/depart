using System.Collections.Generic;
using ClearSky;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private bool isPaused = false; // 判断游戏是否暂停
    public GameObject canvas;
    public Transform player;
    public PlayerController playerController; // 用于引用玩家控制器脚本
    public AudioSource clickSource;

    void Start() 
    {
        canvas.SetActive(false); // 在游戏开始时，将UI Canvas设置为不可见
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanva(1);
        }     

    }

    // 用于接收角色和主摄像机的初始位置，并将它们存储在相应的变量中
    public void GetInitialPosition(Vector3 position1, Vector3 position2){
        initialPositionPlayer = position1;
        initialPositionCamera = position2;
    }

    // 点击继续按钮
    public void OnButtonContinueClick(){
        clickSource.Play();
        ToggleCanva(1);
    }

    // 点击重新开始按钮
    public void OnButtonRestartClick(){
        clickSource.Play();
        // 获取当前活动场景的名称
        string currentSceneName = SceneManager.GetActiveScene().name;
        // 重新加载当前场景
        SceneManager.LoadScene(currentSceneName);
        ToggleCanva(1);
    }

    // 点击下一关按钮
    public void OnButtonNextClick(){
        clickSource.Play();
        // 获取下一个活动场景的索引
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        // 加载下一个场景
        SceneManager.LoadScene(nextSceneIndex);
        ToggleCanva(1);
    }

    // 点击返回标题页按钮
    public void OnButtonReturnClick(){
        clickSource.Play();
        SceneManager.LoadScene("Start");
    }
    
    // 点击退出按钮
    public void OnButtonExitClick(){
        clickSource.Play();
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    
    public void ToggleCanva(int flag){
        canvas.SetActive(!canvas.activeSelf); // 切换UI Canvas的可见性状态
        Debug.Log(canvas.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // 切换游戏时间缩放，实现暂停和继续功能
        isPaused = !isPaused; // 切换游戏暂停状态
        if (playerController != null)
        {
            playerController.SetPaused(isPaused); // 调用PlayerController脚本中的SetPaused方法，传递当前暂停状态
        }
        // 根据参数flag，设置"Exit"按钮的可见性
        canvas.transform.Find("Exit").gameObject.SetActive(flag == 2 ? canvas.activeSelf : !canvas.activeSelf);
        // 根据参数flag，设置"Next Level"按钮的可见性
        canvas.transform.Find("Next Level").gameObject.SetActive(flag == 3 ? canvas.activeSelf : !canvas.activeSelf);
    }

    // 销毁场景中所有带有 "Ball" 标签的游戏对象
    private void DestroyBall(){
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }
}
