using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonExitClick()
    {
        // 退出游戏
        #if UNITY_EDITOR
        // 在编辑模式下停止播放
        EditorApplication.isPlaying = false;
        #else
        // 在构建版本中退出游戏
        Application.Quit();
        #endif
    }
}
