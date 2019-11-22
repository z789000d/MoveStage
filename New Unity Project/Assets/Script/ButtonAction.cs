using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    private int index = 0;
    public new GameObject gameObject;
    public static ButtonAction buttonAction;

    private void Start()
    {
        buttonAction = this;
    }
    public void CreatePrefabs()
    {
        if (Record.record.isRecord)
        {
            return;
        }
        Vector3 position = new Vector3(0, 0, 10);
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        GameObject sceneObject = Instantiate(gameObject, position, quaternion);

        TextMesh textMesh = sceneObject.gameObject.GetComponentInChildren<TextMesh>();

        index++;

        textMesh.text = index.ToString();

    }

    public GameObject CreatePrefabsReturn()
    {
        if (Record.record.isRecord)
        {
            return null;
        }
        Vector3 position = new Vector3(0, 0, 10);
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        GameObject sceneObject = Instantiate(gameObject, position, quaternion);

        TextMesh textMesh = sceneObject.gameObject.GetComponentInChildren<TextMesh>();

        index++;

        textMesh.text = index.ToString();

        return sceneObject;

    }


}
