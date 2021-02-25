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

        private Rigidbody rb;
        private Vector3 startPos;
        private Vector3 endPos;

        private bool moving;
        private bool goingLeft;
        private bool goingRight;

        public float lerpDuration;
        private float timeSpentLerping;
        private string lane = "middle";
        private string laneToLeft = "left";
        private string laneToRight = "right";
        private Vector3 leftDest;
        private Vector3 rightDest;

        // Start is called before the first frame update
        void Start()
        {
            rb = this.GetComponent<Rigidbody>();
            moving = false;
            goingLeft = false;
            goingRight = false;
            timeSpentLerping = 1000;
            lerpDuration = 0.2f;
        }

        // Update is called once per frame
        void Update()
        {
            startPos = gameObject.transform.position;

            //---CAPTURE INPUT---//
            if (Input.GetKeyDown(moveL) || Input.GetKeyDown(moveL_alt))
            {
                if (!moving)
                {
                    goingLeft = true;
                    moving = true;
                    timeSpentLerping = 0;
                }
            }
            if (Input.GetKeyDown(moveR) || Input.GetKeyDown(moveR_alt))
            {
                if (!moving)
                {
                    goingRight = true;
                    moving = true;
                    timeSpentLerping = 0;
                }
            }
            
            
            //---MOVE BIKE---//
            if (moving)
            {
                if (goingLeft)
                {
                    transform.position = Vector3.Lerp(startPos, leftDest, timeSpentLerping / lerpDuration);
                    timeSpentLerping += Time.deltaTime;
                    if (transform.position.x <= leftDest.x)
                    {
                        moving = false;
                        AssignLaneRelations(transform.position);
                        timeSpentLerping = 0;
                        goingLeft = false;
                    }
                }
                if (goingRight)
                {
                    transform.position = Vector3.Lerp(startPos, rightDest, timeSpentLerping / lerpDuration);
                    timeSpentLerping += Time.deltaTime;
                    if (transform.position.x >= rightDest.x)
                    {
                        moving = false;
                        AssignLaneRelations(transform.position);
                        timeSpentLerping = 0;
                        goingRight = false;
                    }
                }
            }       
        }

        private void AssignLaneRelations(Vector3 startPos)
        {
            if (startPos.x == 0)
            {
                lane = "middle";
                laneToLeft = "left";
                leftDest = new Vector3(-1, startPos.y, 0);
                laneToRight = "right";
                rightDest = new Vector3(1, startPos.y, 0);
            }
            else if (startPos.x == -1)
            {
                lane = "left";
                laneToLeft = null;
                laneToRight = "middle";
                rightDest = new Vector3(0, startPos.y, 0);
            }
            else if (startPos.x == 1)
            {
                lane = "right";
                laneToLeft = "middle";
                leftDest = new Vector3(0, startPos.y, 0);
                laneToRight = null;
            }
        }
    }
}
