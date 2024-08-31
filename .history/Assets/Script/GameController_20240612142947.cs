using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start() 
    {
        canvas.SetActive(false);
    }
    void Update() 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            canvas.SetActive(tr);
        }     
    }
}
