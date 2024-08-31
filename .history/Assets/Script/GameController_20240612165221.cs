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
            ToggleCanva(true);
        }     

    }
    public void GetInitialPosition(Vector3 position1, Vector3 position2)
    {
        initialPositionPlayer = position1;
        initialPositionCamera = position2;
    }
    public void OnButtonContinueClick()
    {
        ToggleCanva(true);
    }
    public void OnButtonRestartClick()
    {
        player.position = initialPositionPlayer;
        player.localScale = new Vector3(1, 1, 1);
        Camera.main.transform.position = initialPositionCamera;
        ToggleCanva(true);
        DestroyBall();
        playerController.Restart();
    }
    public void ToggleCanva(bool flag)
    {
        canvas.SetActive(!canvas.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        isPaused = !isPaused;
        playerController.SetPaused(isPaused);
        canvas.transform.Find("Continue").gameObject.SetActive(!flag? !canvas.activeSelf : canvas.activeSelf);
    }
    private void DestroyBall()
    {
        List<Game
    }
}
