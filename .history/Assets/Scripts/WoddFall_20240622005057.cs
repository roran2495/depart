using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoddFall : MonoBehaviour
{
    private ChainAttack chainAttack;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        chainAttack = FindObjectOfType<ChainAttack>();
        rb = GetComponent<Rigidbody2D>();
        // ���ó�ʼʱû������Ӱ��
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(chainAttack.IsAttack){
            rb.gravityScale = 1f;
        }
    }
}