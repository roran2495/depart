using System.Collections.Generic;
using ClearSky;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameController : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject canvas;
    public Transform player;
    public PlayerController playerController;
    private Vector3 initialPositionPlayer; // 角色的初始位置
    private Vector3 initialPositionCamera;
    // Start is called before the first frame update
    void Start() 
    {
        canvas.SetActive(false);
    }
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanva(1);
        }     

    }
    public void GetInitialPosition(Vector3 position1, Vector3 position2)
    {
        initialPositionPlayer = position1;
        initialPositionCamera = position2;
    }
    public void OnButtonContinueClick()
    {
        ToggleCanva(1);
    }
    public void OnButtonRestartClick()
    {
        player.position = initialPositionPlayer;
        player.localScale = new Vector3(1, 1, 1);
        Camera.main.transform.position = initialPositionCamera;
        ToggleCanva(1);
        DestroyBall();
        playerController.Restart();
    }
    public void ToggleCanva(int flag)
    {
        canvas.SetActive(!canvas.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        isPaused = !isPaused;
        playerController.SetPaused(isPaused);
        GameObject button = canvas.transform.Find("Continue").gameObject;
        button.SetActive(flag==2 ? !canvas.activeSelf : canvas.activeSelf);
        if (flag == 3)
        {
            
        }

    }
    private void DestroyBall()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }
}
