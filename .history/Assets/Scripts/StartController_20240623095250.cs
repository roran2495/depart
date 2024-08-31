using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class StartController : MonoBehaviour
{
    private static GameObject interaction;
    private static GameObject canvas;
    private static GameObject choose;
    private static float timer;
    private float waittime = 2.0f;
    public AudioSource clickSource; //点击按钮的音效

    // Start is called before the first frame update
    void Start()
    {
        Transform interactionTransform = transform.Find("interaction");
        if (interactionTransform != null)
        {
            interaction = interactionTransform.gameObject;
            interaction.SetActive(false);
        }
        interactionTransform = transform.Find("canvas");
        if (interactionTransform != null)
        {
            canvas = interactionTransform.gameObject;
        }
        
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction != null && interaction.activeSelf)
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
        clickSource.Play();
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void OnButtonEnterClick()
    {
        clickSource.Play();
        canvas.SetActive(false);
        interaction.SetActive(true);
    }
    public void OnButtonContinueClick()
    {
        clickSource.Play();
        Debug.Log("");
    }
    public void OnButtonReturnClick()
    {
        clickSource.Play();
        SceneManager.LoadScene("Start");
    }
}