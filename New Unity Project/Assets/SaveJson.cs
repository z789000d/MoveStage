using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveJson : MonoBehaviour
{
    string filepath = null;

    // Start is called before the first frame update
    void Start()
    {
        string name = "/my.json";
#if UNITY_EDITOR
        filepath = Application.dataPath + "/StreamingAssets" + name;
#elif UNITY_IPHONE
        filepath = Application.dataPath +"/Raw"+name;
#elif UNITY_ANDROID
        filepath = "jar:file://" + Application.dataPath + "!/assets/"+name;
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Save()
    {
        if (File.Exists(filepath))
        {
            StreamWriter writer = new StreamWriter(filepath, false);
            writer.WriteLine(Record.record.jSONObject.ToString());
            writer.Close();
        }
        else
        {
            File.Create(filepath);
        }
    }

    public void Load()
    {
        Record.record.recordindex = 0;
        Move.move.moveIndex = 0;

        if (File.Exists(filepath))
        {
            JSONObject jSONObject = new JSONObject(File.ReadAllText(filepath));
            Record.record.jSONObject = jSONObject;

            Record.record.recordindex = jSONObject.Count;
            if (Record.record.isRecord)
            {

                GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Sphere");

                for (int j = 0; j < gameObject.Length; j++)
                {

                    Vector3 vector3 = new Vector3(float.Parse(jSONObject.GetField("1").GetField(j.ToString()).GetField("x").ToString().Replace("\"", ""))
                    , float.Parse(jSONObject.GetField("1").GetField(j.ToString()).GetField("y").ToString().Replace("\"", ""))
                    , float.Parse(jSONObject.GetField("1").GetField(j.ToString()).GetField("z").ToString().Replace("\"", "")));

                    gameObject[j].transform.localPosition = vector3;

                }
                return;

            }

            for (int i = 0; i < jSONObject.GetField("1").Count; i++)
            {
                GameObject gameObject = ButtonAction.buttonAction.CreatePrefabsReturn();

                Vector3 vector3 = new Vector3(float.Parse(jSONObject.GetField("1").GetField(i.ToString()).GetField("x").ToString().Replace("\"", ""))
                , float.Parse(jSONObject.GetField("1").GetField(i.ToString()).GetField("y").ToString().Replace("\"", ""))
                , float.Parse(jSONObject.GetField("1").GetField(i.ToString()).GetField("z").ToString().Replace("\"", "")));

                gameObject.transform.localPosition = vector3;
            }

            Record.record.isRecord = true;
        }
    }
}
