using System.Collections.Generic;
using ClearSky;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject canvas;
    public Transform player;
    public PlayerController playerController;
    public AudioSource clickSource;

    private float toggleCooldown = 0.5f; // 冷却时间（秒）
    private float lastToggleTime = -10f; // 上次调用ToggleCanva的时间

    void Start()
    {
        canvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.time - lastToggleTime >= toggleCooldown)
        {
            ToggleCanva(1);
            lastToggleTime = Time.time; // 更新上次切换时间
        }
    }

    public void OnButtonContinueClick()
    {
        clickSource.Play();
        ToggleCanva(1);
    }

    public void OnButtonRestartClick()
    {
        clickSource.Play();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        ToggleCanva(1);
    }

    public void OnButtonNextClick()
    {
        clickSource.Play();
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
        ToggleCanva(1);
    }

    public void OnButtonReturnClick()
    {
        clickSource.Play();
        SceneManager.LoadScene("Start");
    }

    public void OnButtonExitClick()
    {
        clickSource.Play();
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void ToggleCanva(int flag)
    {
        canvas.SetActive(!canvas.activeSelf);
        Debug.Log(canvas.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        isPaused = !isPaused;

        if (playerController != null)
        {
            playerController.SetPaused(isPaused);
        }

        canvas.transform.Find("Exit").gameObject.SetActive(flag == 2 ? canvas.activeSelf : !canvas.activeSelf);
        canvas.transform.Find("Next Level").gameObject.SetActive(flag == 3 ? canvas.activeSelf : !canvas.activeSelf);
    }
}
