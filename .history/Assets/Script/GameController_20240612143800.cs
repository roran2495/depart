using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject canvas;
    private GameObject button1;
    private GameObject button2;
    // Start is called before the first frame update
    void Start() 
    {
        canvas.SetActive(false);
        button1 = canvas.transform.Find("continue").gameObject;
        button1 = canvas.transform.Find("restart").gameObject;
    }
    void Update() 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            canvas.SetActive(!canvas.activeSelf);
        }     

    }
    
}
