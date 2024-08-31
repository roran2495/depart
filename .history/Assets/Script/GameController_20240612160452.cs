using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCanva();
        }     

    }
    public void GetInitialPosition(Vector3 position1, Vector3 position2)
    {
        initialPositionPlayer = position1;
        initialPositionCamera = position2;
    }
    public void OnButtonContinueClick()
    {
        ToggleCanva();
    }
    public void OnButtonRestartClick()
    {
        player.position = initialPositionPlayer;
        player.localScale = new Vector3(1, 1, 1);
        Camera.main.transform.position = initialPositionCamera;
        ToggleCanva();
    }
    public void ToggleCanva()
    {
        canvas.SetActive(!canvas.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
