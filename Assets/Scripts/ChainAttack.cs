using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainAttack : MonoBehaviour
{
    public bool IsAttack = false;
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Ball"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
            IsAttack = true;
        }
    }
}
