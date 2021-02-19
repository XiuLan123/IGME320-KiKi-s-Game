using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float maxHeight = 3;
    float minHeight = 0;
    float raiseSpeed = 2.5f;
    float lowerSpeed = 2.5f;
    public Transform ropeConnectorR;
    public Transform ropeConnectorL;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Right rope control
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(ropeConnectorR.localPosition.y < maxHeight)
            {
                ropeConnectorR.localPosition += new Vector3(0,  Time.deltaTime * raiseSpeed, 0);
            }
            else
            {
                ropeConnectorR.localPosition = new Vector3(ropeConnectorR.localPosition.x, maxHeight, ropeConnectorR.localPosition.z);
            }
        }
        else if(ropeConnectorR.localPosition.y > minHeight)
        {
            ropeConnectorR.localPosition -= new Vector3(0, Time.deltaTime * lowerSpeed, 0);
            if(ropeConnectorR.localPosition.y < minHeight)
            {
                ropeConnectorR.localPosition = new Vector3(ropeConnectorR.localPosition.x, minHeight, ropeConnectorR.localPosition.z);
            }
        }

        //Left rope control
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (ropeConnectorL.localPosition.y < maxHeight)
            {
                ropeConnectorL.localPosition += new Vector3(0, Time.deltaTime * raiseSpeed, 0);
            }
            else
            {
                ropeConnectorL.localPosition = new Vector3(ropeConnectorL.localPosition.x, maxHeight, ropeConnectorL.localPosition.z);
            }
        }
        else if (ropeConnectorL.localPosition.y > minHeight)
        {
            ropeConnectorL.localPosition -= new Vector3(0, Time.deltaTime * lowerSpeed, 0);
            if (ropeConnectorL.localPosition.y <= minHeight)
            {
                ropeConnectorL.localPosition = new Vector3(ropeConnectorL.localPosition.x, minHeight, ropeConnectorL.localPosition.z);
            }
        }
    }
}
