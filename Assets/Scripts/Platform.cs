using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject[] routePoints;
    private int current = 0;
    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(routePoints[current].transform.position, transform.position) < .1f){
            current++;
            if(current >= routePoints.Length){
                current = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, routePoints[current].transform.position, Time.deltaTime * speed);
    }
}
