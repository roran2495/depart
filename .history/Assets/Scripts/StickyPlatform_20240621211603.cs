using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ����ɫ���봥����ʱ
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            // ����ײ������Ʒ����Ϊ��ǰ�����������
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // ����ɫ�뿪������ʱ
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.transform.SetParent(null);
        }
    }
}
