using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonTest : MonoBehaviour
{

    string jsonString = "{" + "\"" + "index1" + "\"" + ":" + "\"" + "1" + "\"" + "}";

    // Start is called before the first frame update
    void Start()
    {
        JSONObject jSONObject = new JSONObject(jsonString);
        Debug.Log(jSONObject.GetField("index1"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
