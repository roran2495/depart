﻿using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject canvas;
    public Button button1;
    public Button button2;
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
}
