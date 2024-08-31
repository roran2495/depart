using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class StartController : MonoBehaviour
{
    private interaction;
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
    public void OnButtonEnterClick()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void OnButtonContinueClick()
    {
        Debug.Log("需要从缓存中调取跳转到上次退出的关卡，没写");
    }
}
