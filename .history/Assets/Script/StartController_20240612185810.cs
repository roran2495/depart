using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class StartController : MonoBehaviour
{
    private GameObject interaction;
    private static GameObject canvas;
    private static float timer;
    private float waittime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        interaction = transform.Find("interaction").gameObject;
        canvas = transform.Find("canvas").gameObject;
        interaction.SetActive(false);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer > waittime)
            {
                SceneManager.LoadScene("Level 1");
            }
        }
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
        canvas.SetActive(false);
        interaction.SetActive(true);
    }
    public void OnButtonContinueClick()
    {
        Debug.Log("需要从缓存中调取跳转到上次退出的关卡，没写");
    }
    public static void Resume()
    {
        timer = 0;
        interaction.SetActive(false);
        canvas.SetActive(true);
    }
}
