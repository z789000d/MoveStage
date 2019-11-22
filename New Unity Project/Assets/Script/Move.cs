using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public static Move move;

    bool canMove = false;

    new GameObject[] gameObject;

    public int moveIndex = 0;

    private void Start()
    {
        move = this;
    }

    public void MoveAction()
    {

        if (moveIndex < Record.record.recordindex)
        {
            moveIndex++;
        }
        else
        {
            moveIndex = 1;
        }

        canMove = true;

        gameObject = GameObject.FindGameObjectsWithTag("Sphere");


    }

    private void Update()
    {
        if (canMove)
        {
            int arriveindex = 0;
            for (int i = 0; i < gameObject.Length; i++)
            {
                Vector3 vector3 = new Vector3(
                    float.Parse(Record.record.jSONObject.GetField(moveIndex.ToString()).GetField(i.ToString()).GetField("x").ToString().Replace("\"", "")),
                    float.Parse(Record.record.jSONObject.GetField(moveIndex.ToString()).GetField(i.ToString()).GetField("y").ToString().Replace("\"", "")),
                    float.Parse(Record.record.jSONObject.GetField(moveIndex.ToString()).GetField(i.ToString()).GetField("z").ToString().Replace("\"", "")));
                if (gameObject[i].transform.localPosition == vector3)
                {
                    arriveindex++;
                    if (arriveindex == gameObject.Length)
                    {
                        canMove = false;
                    }
                }
                else
                {

                    float step = 5 * Time.deltaTime;

                    gameObject[i].transform.localPosition = Vector3.MoveTowards(gameObject[i].transform.localPosition, vector3, step);

                }
            }

        }
    }
}
