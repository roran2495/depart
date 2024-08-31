using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    private Vector3 initialPosition; // 角色的初始位置
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
    public void GetInitialPosition(Vector3 position)
    {
        initialPosition = position;
    }
    public void OnButtonContinueClick()
    {

    }
    public void OnButtonRestartClick()
    {

    }
}
