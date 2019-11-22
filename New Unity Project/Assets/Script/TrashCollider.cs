using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider trigger) //aaa為自定義碰撞事件
    {

        if (trigger.gameObject.tag == "Sphere") //如果aaa碰撞事件的物件標籤名稱是test
        {
            Destroy(trigger.gameObject); //刪除碰撞到的物件(CubeA)
        }

        Debug.Log(trigger.gameObject.name);
    }
}
