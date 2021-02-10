using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{
    KeyCode moveL = KeyCode.LeftArrow;
    KeyCode moveR = KeyCode.RightArrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = gameObject.transform.position;

        if (Input.GetKeyDown(moveL) && curPos.x > -1)
        {
            gameObject.transform.position = Vector3.MoveTowards(curPos, curPos - new Vector3(1, 0, 0), 1);
        }
        if (Input.GetKeyDown(moveR) && curPos.x < 1)
        {
            gameObject.transform.position = Vector3.MoveTowards(curPos, curPos + new Vector3(1, 0, 0), 1);
        }
    }
}
