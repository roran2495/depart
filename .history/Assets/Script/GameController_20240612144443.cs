﻿using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject canvas;
    public Transform player;
    private Vector3 initialPositionPlayer; // 角色的初始位置
    private Vector3 initialPositionCamera;
    // Start is called before the first frame update
    void Start() 
    {
        canvas.SetActive(false);
    }
    void Update() 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            canvas.SetActive(!canvas.activeSelf);
        }     

    }
    public void GetInitialPosition(Vector3 position, Vector3 position2)
    {
        initialPositionPlayer = position;
        initialPositionCamera = 
    }
    public void OnButtonContinueClick()
    {

    }
    public void OnButtonRestartClick()
    {
        player.position = initialPosition;
    }
}
