using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    new GameObject gameObject = null;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (gameObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Trash")
                    {
                        return;
                    }
                    gameObject = hit.collider.gameObject;
                }
            }

            if (gameObject == null)
            {
                return;
            }

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
        else
        {
            gameObject = null;
        }
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (gameObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Trash")
                    {
                        return;
                    }
                    gameObject = hit.collider.gameObject;
                }
            }

            if (gameObject == null)
            {
                return;
            }

            Vector3 touchPosition = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 10);
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(touchPosition);
        }
        else
        {
            gameObject = null;
        }

#endif
    }
}
