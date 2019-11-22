using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Record : MonoBehaviour
{

    public static Record record;

    public int recordindex = 0;

    public  JSONObject jSONObject;

    public bool isRecord = false;


    private void Start()
    {
        record = this;

        jSONObject = new JSONObject();

    }

    public void RecordAction()
    {

        isRecord = true;

        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Sphere");

        Vector3[] allRecord;

        allRecord = new Vector3[gameObject.Length];


        JSONObject jSONObject2 = new JSONObject();

        for (int i = 0; i < gameObject.Length; i++)
        {
            JSONObject jSONObject1 = new JSONObject();

            jSONObject1.AddField("x",
                                 gameObject[i].gameObject.transform.localPosition.x.ToString());
            jSONObject1.AddField("y",
                                 gameObject[i].gameObject.transform.localPosition.y.ToString());
            jSONObject1.AddField("z",
                               gameObject[i].gameObject.transform.localPosition.z.ToString());
            jSONObject2.SetField(i.ToString(), jSONObject1);
        }

        recordindex++;

        jSONObject.SetField(recordindex.ToString(), jSONObject2);

        Debug.Log(jSONObject.ToString());

    }
}



