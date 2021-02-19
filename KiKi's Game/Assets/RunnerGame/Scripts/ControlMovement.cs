using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class ControlMovement : MonoBehaviour
    {
        KeyCode moveL = KeyCode.LeftArrow;
        KeyCode moveR = KeyCode.RightArrow;
        KeyCode moveL_alt = KeyCode.A;
        KeyCode moveR_alt = KeyCode.D;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector3 curPos = gameObject.transform.position;

            if (Input.GetKeyDown(moveL) || Input.GetKeyDown(moveL_alt) && curPos.x > -1)
            {
                gameObject.transform.position = Vector3.MoveTowards(curPos, curPos - new Vector3(1, 0, 0), 1);
            }
            if (Input.GetKeyDown(moveR) || Input.GetKeyDown(moveR_alt) && curPos.x < 1)
            {
                gameObject.transform.position = Vector3.MoveTowards(curPos, curPos + new Vector3(1, 0, 0), 1);
            }
        }
    }
}
