using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoveRecordIndex : MonoBehaviour
{

    public Text recordIndex;
    public Text moveIndex;

    // Update is called once per frame
    void Update()
    {
        recordIndex.text = "RecordIndex: " + Record.record.recordindex;
        moveIndex.text = "MoveIndex: " + Move.move.moveIndex;
    }
}
